using System;
using System.ComponentModel;
using System.Reflection;

namespace Octopus.Server.Extensibility.Metadata
{
    public static class EnumExtensions
    {
        public static string GetDescription(Type enumType, object value)
        {
            var type = value.GetType().GetTypeInfo();
            if (!type.IsEnum) throw new ArgumentException($"{enumType.Name} must be an Enum type", nameof(enumType));
            var info = type.GetDeclaredField(value.ToString());
            var attr = info?.GetCustomAttribute(typeof(DescriptionAttribute), false);
            if (attr != null) return ((DescriptionAttribute) attr).Description;
            return value.ToString();
        }
    }
}