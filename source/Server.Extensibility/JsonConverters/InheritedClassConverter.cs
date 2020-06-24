using System;
using System.Collections.Generic;
using System.Reflection;

namespace Octopus.Server.Extensibility.JsonConverters
{
    public abstract class
        InheritedClassConverter<TBaseClass, TDiscriminator> : InheritedClassConverterBase<TBaseClass, TDiscriminator>
    {
        protected override TypeInfo GetTypeInfoFromDerivedType(string derivedType)
        {
            var type = typeof(TDiscriminator);

            if (type.IsEnum)
            {
                var enumType = (TDiscriminator) Enum.Parse(type, derivedType);
                if (!DerivedTypeMappings.ContainsKey(enumType))
                    throw new Exception(
                        $"Unable to determine type to deserialize. {TypeDesignatingPropertyName} `{enumType}` does not map to a known type");

                return DerivedTypeMappings[enumType].GetTypeInfo();
            }

            if (type == typeof(string))
            {
                var mappings = (Dictionary<string, Type>) DerivedTypeMappings;
                if (!mappings.ContainsKey(derivedType))
                    throw new Exception(
                        $"Unable to determine type to deserialize. {TypeDesignatingPropertyName} `{derivedType}` does not map to a known type");

                return mappings[derivedType].GetTypeInfo();
            }

            throw new Exception(
                "Unable to determine type to deserialize, override GetTypeInfoFromDerivedType to map the derivedType");
        }
    }

    public abstract class InheritedClassConverter<TBaseClass> : InheritedClassConverter<TBaseClass, string>
    {
    }
}