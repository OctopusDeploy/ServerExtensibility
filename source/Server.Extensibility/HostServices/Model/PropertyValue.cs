using System;
using Octopus.Server.MessageContracts;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public class PropertyValue : IEquatable<PropertyValue>
    {
        public PropertyValue(string value, bool isSensitive = false)
        {
            Value = value ?? string.Empty;
            IsSensitive = isSensitive;
        }

        public string Value { get; }

        public bool IsSensitive { get; }

        public bool HasValue => !string.IsNullOrEmpty(Value);

        public bool Equals(PropertyValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value) && IsSensitive.Equals(other.IsSensitive);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PropertyValue)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value != null ? Value.GetHashCode() : 0) * 397) ^ IsSensitive.GetHashCode();
            }
        }

        public static bool operator ==(PropertyValue left, PropertyValue right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PropertyValue left, PropertyValue right)
        {
            return !Equals(left, right);
        }

        public static explicit operator string?(PropertyValue v)
        {
            return v?.Value;
        }

        public static explicit operator PropertyValue(string v)
        {
            return new PropertyValue(v);
        }

        public static explicit operator PropertyValue(DateTime v)
        {
            return new PropertyValue(v.ToString());
        }

        public override string ToString()
        {
            return Value;
        }

        public PropertyValue Clone()
        {
            return new PropertyValue(Value, IsSensitive);
        }
    }

    public static class PropertyValueExtensionMethods
    {
        public static PropertyValue ToModel(this PropertyValueResource resource)
        {
            return new PropertyValue(resource.IsSensitive ? resource.SensitiveValue.NewValue : resource.Value, resource.IsSensitive);
        }
    }
}