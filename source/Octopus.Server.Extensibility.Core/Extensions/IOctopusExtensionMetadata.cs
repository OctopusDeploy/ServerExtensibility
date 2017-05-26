using System;

namespace Octopus.Server.Extensibility.Extensions
{
    public interface IOctopusExtensionMetadata
    {
        string Author { get; }
        string FriendlyName { get; }
    }
}