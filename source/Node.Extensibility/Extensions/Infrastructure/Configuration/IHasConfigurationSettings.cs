using System;
using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasConfigurationSettings
    {
        string Id { get; }

        string ConfigurationSetName { get; }

        string Description { get; }

        Type MetadataResourceType { get; }

        object GetConfiguration();

        void SaveConfiguration(object config);

        IEnumerable<ConfigurationValue> GetConfigurationValues();
    }
}