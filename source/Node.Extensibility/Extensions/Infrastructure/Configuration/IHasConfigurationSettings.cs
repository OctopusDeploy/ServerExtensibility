using System.Collections.Generic;
using Octopus.Node.Extensibility.Extensions.Mappings;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasConfigurationSettings : IHasConfigurationSettingsResource, IContributeMappings
    {
        object GetConfiguration();

        void SetConfiguration(object config);

        IEnumerable<ConfigurationValue> GetConfigurationValues();
    }
}