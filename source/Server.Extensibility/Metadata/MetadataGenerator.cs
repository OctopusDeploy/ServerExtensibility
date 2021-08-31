﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using Octopus.Server.MessageContracts;
using Octopus.Server.MessageContracts.Attributes;
using Octopus.Server.MessageContracts.Features.Projects;

namespace Octopus.Server.Extensibility.Metadata
{
    public class MetadataGenerator : IGenerateMetadata
    {
        //property names to be ignored on any object
        readonly HashSet<string> ignoreProperties = new()
        {
            "LastModifiedBy",
            "LastModifiedOn",
            "Id"
        };

        //the approved types we will map to metadata, and how to stringify them
        readonly Dictionary<Type, string> mappings = new()
        {
            { typeof(string), "string" },
            { typeof(int), "int" },
            { typeof(DateTime), "DateTime" },
            { typeof(DateTimeOffset), "DateTimeOffset" },
            { typeof(bool), "bool" },
            { typeof(long), "long" },
            { typeof(SensitiveValue), "SensitiveValue" },
            { typeof(DeploymentActionPackageResource), "DeploymentActionPackage" }
        };

        readonly Metadata metadata;

        public MetadataGenerator()
        {
            metadata = new Metadata
            {
                Types = new List<TypeMetadata>()
            };
        }

        public Metadata GetMetadata<T>()
        {
            return GetMetadata(typeof(T));
        }

        public Metadata GetMetadata(Type objectType)
        {
            Generate(objectType);
            metadata.Description = objectType.GetTypeInfo().GetCustomAttribute<DescriptionAttribute>()?.Description;
            return metadata;
        }

        //will generate a type representing the passed-in type, and return the string
        //name of the type
        string Generate(Type type)
        {
            //root type is submitted
            var rootType = new TypeMetadata
            {
                Name = type.Name,
                Properties = new List<PropertyMetadata>()
            };

            metadata.Types.Add(rootType);

            var props = type.GetRuntimeProperties();

            foreach (var prop in props)
                //skip these
                if (prop.PropertyType != typeof(LinkCollection) && !ignoreProperties.Contains(prop.Name))
                {
                    var propMetadata = new PropertyMetadata
                    {
                        Name = prop.Name,
                        Type = GetTypeDescriptor(prop.PropertyType),
                        DisplayInfo = new DisplayInfo
                        {
                            Required = prop.IsDefined(typeof(RequiredAttribute)),
                            Description = prop.GetCustomAttribute<DescriptionAttribute>()?.Description,
                            ShowCopyToClipboard = prop.IsDefined(typeof(AllowCopyToClipboardAttribute))
                        }
                    };

                    //accepts [DisplayName()] or [Display(Name=)] -> defaults to property name
                    if (prop.IsDefined(typeof(DisplayNameAttribute)))
                        propMetadata.DisplayInfo.Label = prop.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName ?? string.Empty;
                    else if (prop.IsDefined(typeof(DisplayAttribute)))
                        propMetadata.DisplayInfo.Label = prop.GetCustomAttribute<DisplayAttribute>()?.Name ?? string.Empty;
                    else
                        propMetadata.DisplayInfo.Label = prop.Name;

                    //accepts [ReadOnly()] or [Writeable] -> defaults to true (Read Only)
                    if (prop.IsDefined(typeof(ReadOnlyAttribute)))
                        propMetadata.DisplayInfo.ReadOnly = prop.GetCustomAttribute<ReadOnlyAttribute>().IsReadOnly;
                    else if (prop.IsDefined(typeof(WriteableAttribute)))
                        propMetadata.DisplayInfo.ReadOnly = false;
                    else
                        propMetadata.DisplayInfo.ReadOnly = true;

                    //selectable metadata is not currently supported in the UI
                    if (prop.IsDefined(typeof(SelectableAttribute)))
                    {
                        if (prop.IsDefined(typeof(HasOptionsAttribute)))
                        {
                            var optionsAttr = prop.GetCustomAttribute<HasOptionsAttribute>();

                            propMetadata.DisplayInfo.Options = new OptionsMetadata
                            {
                                SelectMode = optionsAttr.SelectMode.ToString()
                            };

                            if (prop.PropertyType.GetTypeInfo().IsEnum)
                            {
                                var enumType = prop.PropertyType;

                                propMetadata.DisplayInfo.Options.Values = ProjectEnum(enumType);
                            }
                        }
                        else if (prop.IsDefined(typeof(ListApiAttribute)))
                        {
                            var listApiAttr = prop.GetCustomAttribute<ListApiAttribute>();

                            propMetadata.DisplayInfo.ListApi = new ListApiMetadata(listApiAttr.SelectMode.ToString(), listApiAttr.ApiEndpoint);
                        }
                    }

                    if (prop.IsDefined(typeof(PropertyApplicabilityAttribute)))
                    {
                        var applicableAttr = prop.GetCustomAttribute<PropertyApplicabilityAttribute>();

                        propMetadata.DisplayInfo.PropertyApplicability = new PropertyApplicability(applicableAttr.Mode, applicableAttr.DependsOnPropertyName)
                        {
                            DependsOnPropertyValue = applicableAttr.DependsOnPropertyValue
                        };
                    }

                    if (prop.IsDefined(typeof(AllowConnectivityCheckAttribute)))
                    {
                        var allowConnectivityCheckAttr = prop.GetCustomAttribute<AllowConnectivityCheckAttribute>();
                        propMetadata.DisplayInfo.ConnectivityCheck = new ConnectivityCheck
                        {
                            Title = allowConnectivityCheckAttr.ConnectivityCheckTitle,
                            Url = allowConnectivityCheckAttr.ApiEndpoint,
                            DependsOnPropertyNames = allowConnectivityCheckAttr.DependsOnPropertyNames
                        };
                    }

                    rootType.Properties.Add(propMetadata);
                }

            return rootType.Name;
        }

        Dictionary<string, string> ProjectEnum(Type enumType)
        {
            if (!enumType.GetTypeInfo().IsEnum) throw new Exception("Parameter must be an enum");

            var values = new Dictionary<string, string>();

            foreach (var item in Enum.GetValues(enumType))
                values.Add(item.ToString(), EnumExtensions.GetDescription(enumType, item));

            return values;
        }

        string GetTypeDescriptor(Type type)
        {
            //Array
            if (type.IsArray) return GetTypeDescriptor(type.GetElementType()) + "[]";

            if (type.GetTypeInfo().IsGenericType)
            {
                var genericTypeDefinition = type.GetGenericTypeDefinition();

                if (genericTypeDefinition != null)
                {
                    //List<>
                    if (genericTypeDefinition.GetTypeInfo().IsAssignableFrom(typeof(List<>).GetTypeInfo()))
                    {
                        var genericType = type.GetTypeInfo().GenericTypeArguments[0];

                        return GetTypeDescriptor(genericType) + "[]";
                    }

                    //Dictionary<>
                    if (genericTypeDefinition.GetTypeInfo().IsAssignableFrom(typeof(Dictionary<,>).GetTypeInfo()))
                    {
                        var genericTypes = type.GetTypeInfo().GenericTypeArguments;

                        var keyType = GetTypeDescriptor(genericTypes[0]);
                        var valueType = GetTypeDescriptor(genericTypes[1]);

                        return $"Dictionary<{keyType}, {valueType}>";
                    }

                    //other generics not supported yet
                }
            }

            //Nullable
            var underlyingType = Nullable.GetUnderlyingType(type);

            if (underlyingType != null) return GetTypeDescriptor(underlyingType) + "?";

            //Enum
            if (type.GetTypeInfo().IsEnum)
                //for enums, we will map the values into the property itself and assume a
                // string on the wire
                return "string";

            //approved primitive / value-type mappings
            if (mappings.TryGetValue(type, out var descriptor)) return descriptor;

            //if we drop down here, first check if the type is already mapped:
            //if not, map the type into the types collection and just
            //return the type name to link them together

            if (metadata.Types.All(t => t.Name != type.Name)) return Generate(type);

            //otherwise we just return the already mapped name :)
            return type.Name;
        }
    }
}