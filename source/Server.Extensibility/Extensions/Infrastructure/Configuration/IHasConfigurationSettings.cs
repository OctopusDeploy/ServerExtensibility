using Octopus.Server.Extensibility.Extensions.Mappings;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasConfigurationSettings : IHasConfigurationSettingsResource, IContributeMappings
    {
        object GetConfiguration();

        void SetConfiguration(object config);
    }
}