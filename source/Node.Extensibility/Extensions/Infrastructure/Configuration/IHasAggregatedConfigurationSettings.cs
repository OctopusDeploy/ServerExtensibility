using System;
using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasAggregatedConfigurationSettings : IHasConfigurationSettingsResource
    {
        IEnumerable<ConfigurationValue> GetConfigurationValues();

        object GetConfigurationResource();
    }
}