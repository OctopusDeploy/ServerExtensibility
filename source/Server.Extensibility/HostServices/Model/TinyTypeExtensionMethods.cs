using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public static class TinyTypeExtensionMethods
    {
        public static TTinyType? ToTinyType<TTinyType>(this string item) where TTinyType : TinyType<string>
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (item == null) return null;
            return (TTinyType)Activator.CreateInstance(typeof(TTinyType), item);
        }
    }
}
