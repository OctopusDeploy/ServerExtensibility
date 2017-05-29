using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IContributeToConfigureCommand
    {
        IEnumerable<ConfigureCommandOption> GetOptions();
    }
}