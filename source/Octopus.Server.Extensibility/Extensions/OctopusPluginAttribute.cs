using System;

namespace Octopus.Server.Extensibility.Extensions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class OctopusPluginAttribute : Attribute, IOctopusExtensionMetadata
    {
        public OctopusPluginAttribute(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        public string FriendlyName { get; set; }
    }
}