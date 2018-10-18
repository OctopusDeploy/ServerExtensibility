namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasAggregatedConfigurationSettings : IHasConfigurationSettingsResource
    {
        object GetConfigurationResource();
    }
}