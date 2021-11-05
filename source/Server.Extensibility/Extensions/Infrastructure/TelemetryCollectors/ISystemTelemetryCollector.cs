using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.TelemetryCollectors
{
    public interface ISystemTelemetryCollector
    {
        Task<KeyValuePair<string, object>> Collect(CancellationToken cancellationToken);
    }
}