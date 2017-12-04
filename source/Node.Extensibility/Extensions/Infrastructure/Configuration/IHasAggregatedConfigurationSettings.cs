using System;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasAggregatedConfigurationSettings : IHasConfigurationSettingsResource
    {
        object GetConfigurationResource();
    }
}