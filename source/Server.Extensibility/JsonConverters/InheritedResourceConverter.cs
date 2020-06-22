using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Octopus.Server.Extensibility.JsonConverters
{
    public abstract class InheritedResourceConverter<TBaseResource> : JsonConverter
    {
        readonly ConcurrentDictionary<Type, IReadOnlyList<PropertyInfo>> readablePropertiesCache = new ConcurrentDictionary<Type, IReadOnlyList<PropertyInfo>>();
        readonly ConcurrentDictionary<Type, IReadOnlyList<PropertyInfo>> writeablePropertiesCache = new ConcurrentDictionary<Type, IReadOnlyList<PropertyInfo>>();

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }
            
            writer.WriteStartObject();

            var properties = readablePropertiesCache.GetOrAdd(
                value.GetType(),
                t => value.GetType()
                    .GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)
                    .Where(p => p.CanRead)
                    .ToArray()
            );
            foreach (var property in properties)
            {
                writer.WritePropertyName(property.Name);
                serializer.Serialize(writer, property.GetValue(value, null));
            }

            WriteTypeProperty(writer, value, serializer);

            writer.WriteEndObject();
        }

        protected virtual void WriteTypeProperty(JsonWriter writer, object value, JsonSerializer serializer)
        { }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            var jo = JObject.Load(reader);
            var designatingProperty = jo.GetValue(TypeDesignatingPropertyName);
            if (designatingProperty == null)
            {
                throw new Exception($"Null value returned for the Type Designator");
            }

            var derivedType = designatingProperty.ToObject<string>() ?? string.Empty;
            if (!DerivedTypeMappings.ContainsKey(derivedType))
            {
                throw new Exception($"Unable to determine type to deserialize. {TypeDesignatingPropertyName} `{derivedType}` does not map to a known type");
            }

            var type = DerivedTypeMappings[derivedType];

            var ctor = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance).Single();
            var args = ctor.GetParameters().Select(p =>
                jo.GetValue(char.ToUpper(p.Name[0]) + p.Name.Substring(1))?
                    .ToObject(p.ParameterType, serializer)).ToArray();
            var instance = ctor.Invoke(args);

            var properties = writeablePropertiesCache.GetOrAdd(
                type,
                t => t.GetProperties(BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.Instance)
                    .Where(p => p.CanWrite)
                    .ToArray()
            );

            foreach (var prop in properties)
            {
                var val = jo.GetValue(prop.Name);
                if (val != null)
                    prop.SetValue(instance, val.ToObject(prop.PropertyType, serializer), null);
            }
            return instance;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(TBaseResource).IsAssignableFrom(objectType);
        }

        protected abstract IDictionary<string, Type> DerivedTypeMappings { get; }

        protected abstract string TypeDesignatingPropertyName { get; }
    }
}