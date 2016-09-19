using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Configuration
{
    public interface IHasConfigurationSettings
    {
        string ConfigurationSetName { get; }
        IEnumerable<ConfigurationValue> GetConfigurationValues();
    }
}