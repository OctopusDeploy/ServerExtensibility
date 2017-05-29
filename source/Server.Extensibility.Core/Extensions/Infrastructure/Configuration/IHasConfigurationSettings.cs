using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasConfigurationSettings
    {
        string ConfigurationSetName { get; }
        IEnumerable<ConfigurationValue> GetConfigurationValues();
    }
}