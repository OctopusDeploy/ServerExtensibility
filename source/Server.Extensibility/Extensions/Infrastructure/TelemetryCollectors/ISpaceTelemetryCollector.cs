using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Octopus.Server.MessageContracts.Features.Spaces;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.TelemetryCollectors
{
    public interface ISpaceTelemetryCollector
    {
        Task<KeyValuePair<string, object>> CollectForSpace(SpaceId spaceId, CancellationToken cancellationToken);
        Task<KeyValuePair<string, object>> CollectForAllSpaces(CancellationToken cancellationToken);
    }
}