using System;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHasAggregatedConfigurationSettingsAsync : IHasConfigurationSettingsResourceAsync
    {
        Task<object> GetConfigurationResource(CancellationToken cancellationToken);
    }
}