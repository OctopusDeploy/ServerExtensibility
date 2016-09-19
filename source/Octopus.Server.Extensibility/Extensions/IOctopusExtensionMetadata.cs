using System;

namespace Octopus.Server.Extensibility.Extensions
{
    public interface IOctopusExtensionMetadata
    {
        string FriendlyName { get; }
    }
}