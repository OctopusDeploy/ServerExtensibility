using System;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public class PropertyValue : IEquatable<PropertyValue>
    {
        readonly string value;
        readonly bool isSensitive;

        public PropertyValue(string value, bool isSensitive = false)
        {
            this.value = value ?? string.Empty;
            this.isSensitive = isSensitive;
        }

        public string Value => value;

        public bool IsSensitive => isSensitive;

        public bool HasValue => !string.IsNullOrEmpty(Value);

        public bool Equals(PropertyValue other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(value, other.value) && isSensitive.Equals(other.isSensitive);
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
                return ((value != null ? value.GetHashCode() : 0) * 397) ^ isSensitive.GetHashCode();
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

        public static explicit operator string(PropertyValue v)
        {
            return v?.value;
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
            return value;
        }

        public PropertyValue Clone()
        {
            return new PropertyValue(value, isSensitive);
        }
    }
}