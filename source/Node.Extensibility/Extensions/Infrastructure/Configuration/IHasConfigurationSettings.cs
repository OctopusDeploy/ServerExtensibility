using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasConfigurationSettings : IHasConfigurationSettingsResource
    {
        object GetConfiguration();

        void SetConfiguration(object config);

        IEnumerable<ConfigurationValue> GetConfigurationValues();
    }
}