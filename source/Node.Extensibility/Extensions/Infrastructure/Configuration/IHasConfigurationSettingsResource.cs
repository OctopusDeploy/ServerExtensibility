using System;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasConfigurationSettingsResource
    {
        string Id { get; }

        string ConfigurationSetName { get; }

        string Description { get; }

        Type MetadataResourceType { get; }
    }
}