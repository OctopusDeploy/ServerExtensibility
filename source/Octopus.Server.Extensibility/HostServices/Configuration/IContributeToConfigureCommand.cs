using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Configuration
{
    public interface IContributeToConfigureCommand
    {
        IEnumerable<ConfigureCommandOption> GetOptions();
    }
}