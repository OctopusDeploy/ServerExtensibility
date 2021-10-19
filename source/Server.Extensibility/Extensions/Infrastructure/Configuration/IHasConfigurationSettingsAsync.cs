using System;
using System.Threading;
using System.Threading.Tasks;
using Octopus.Server.Extensibility.Extensions.Mappings;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasConfigurationSettingsAsync : IHasConfigurationSettingsResourceAsync, IContributeMappings
    {
        Task<object> GetConfiguration(CancellationToken cancellationToken);

        Task SetConfiguration(object config, CancellationToken cancellationToken);
    }
}