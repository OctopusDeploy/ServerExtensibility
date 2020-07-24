using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IContributeToConfigureCommand
    {
        IEnumerable<ConfigureCommandOption> GetOptions();
    }
}