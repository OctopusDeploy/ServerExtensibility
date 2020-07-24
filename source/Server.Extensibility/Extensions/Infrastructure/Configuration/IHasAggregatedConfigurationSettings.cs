using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    //note: we are hoping to get rid of this interface
    public interface IHasAggregatedConfigurationSettings : IHasConfigurationSettingsResource
    {
        object GetConfigurationResource();
    }
}