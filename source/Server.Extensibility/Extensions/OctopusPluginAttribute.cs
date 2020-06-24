using System;

namespace Octopus.Server.Extensibility.Extensions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class OctopusPluginAttribute : Attribute, IOctopusExtensionMetadata
    {
        public OctopusPluginAttribute(string friendlyName, string author)
        {
            FriendlyName = friendlyName;
            Author = author;
        }

        public string FriendlyName { get; }
        public string Author { get; }
    }
}