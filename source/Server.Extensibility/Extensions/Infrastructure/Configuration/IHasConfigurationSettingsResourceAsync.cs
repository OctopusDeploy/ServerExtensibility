using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasConfigurationSettingsResourceAsync
    {
        string Id { get; }

        string ConfigurationSetName { get; }

        string Description { get; }

        Type MetadataResourceType { get; }

        IAsyncEnumerable<IConfigurationValue> GetConfigurationValues();
    }
}