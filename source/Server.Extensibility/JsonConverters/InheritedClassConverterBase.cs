using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Octopus.Server.Extensibility.JsonConverters
{
    public abstract class InheritedClassConverterBase<TBaseClass, TDiscriminator> : JsonConverter
    {
        readonly ConcurrentDictionary<TypeInfo, IReadOnlyList<PropertyInfo>> unmappedReadablePropertiesCache = new();
        readonly ConcurrentDictionary<TypeInfo, IReadOnlyList<PropertyInfo>> writeablePropertiesCache = new();

        protected virtual Type? DefaultType { get; } = null;

        protected abstract IDictionary<TDiscriminator, Type> DerivedTypeMappings { get; }

        protected abstract string TypeDesignatingPropertyName { get; }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            writer.WriteStartObject();

            var documentType = value.GetType().GetTypeInfo();

            // Always write the designating property first
            writer.WritePropertyName(TypeDesignatingPropertyName);
            serializer.Serialize(writer, documentType.GetProperty(TypeDesignatingPropertyName)?.GetValue(value, null));

            var properties = unmappedReadablePropertiesCache.GetOrAdd(documentType, GetReadableProperties);
            foreach (var property in properties)
            {
                writer.WritePropertyName(property.Name);
                serializer.Serialize(writer, GetPropertyValue(property, value));
            }

            writer.WriteEndObject();
        }

        IReadOnlyList<PropertyInfo> GetReadableProperties(TypeInfo documentType)
        {
            return documentType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)
                               .Where(p => p.Name != TypeDesignatingPropertyName
                                           && p.CanRead
                                           && p.GetCustomAttribute(typeof(JsonIgnoreAttribute)) == null)
                               .ToArray();
        }

        protected virtual object? GetPropertyValue(PropertyInfo property, object instance)
        {
            return property.GetValue(instance, null);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jo = JObject.Load(reader);
            var designatingProperty = jo.GetValue(TypeDesignatingPropertyName);
            TypeInfo typeInfo;
            if (designatingProperty == null)
            {
                if (DefaultType == null)
                    throw new Exception($"Unable to determine type to deserialize. Missing property `{TypeDesignatingPropertyName}`");
                typeInfo = DefaultType.GetTypeInfo();
            }
            else
            {
                var derivedType = designatingProperty.ToObject<string>() ?? string.Empty;
                typeInfo = GetTypeInfoFromDerivedType(derivedType);
            }

            var ctor = typeInfo.GetConstructors(BindingFlags.Public | BindingFlags.Instance).FirstOrDefault();
            if (ctor == null) throw new Exception($"Type {typeInfo.Name} must have a public constructor");

            var args = ctor.GetParameters()
                           .Select(p =>
                                       jo.GetValue(char.ToUpper(p.Name[0]) + p.Name.Substring(1))?.ToObject(p.ParameterType, serializer))
                           .ToArray();
            var instance = ctor.Invoke(args);

            var properties = writeablePropertiesCache.GetOrAdd(typeInfo, GetWritableProperties);
            foreach (var prop in properties)
            {
                var val = jo.GetValue(prop.Name);
                if (val != null)
                {
                    var value = val.ToObject(prop.PropertyType, serializer);
                    SetPropertyValue(prop, instance, value);
                }
            }

            return instance;
        }

        IReadOnlyList<PropertyInfo> GetWritableProperties(TypeInfo type)
        {
            return type
                   .GetProperties(BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance)
                   .Where(p => p.CanWrite && p.GetCustomAttribute(typeof(JsonIgnoreAttribute)) == null)
                   .ToArray();
        }

        protected virtual void SetPropertyValue(PropertyInfo prop, object instance, object? value)
        {
            prop.SetValue(instance, value, null);
        }

        protected abstract TypeInfo GetTypeInfoFromDerivedType(string derivedType);

        public override bool CanConvert(Type objectType)
        {
            return typeof(TBaseClass).GetTypeInfo().IsAssignableFrom(objectType);
        }
    }
}