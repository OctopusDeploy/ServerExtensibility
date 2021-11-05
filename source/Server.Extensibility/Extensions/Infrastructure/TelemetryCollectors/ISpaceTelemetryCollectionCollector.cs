using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Octopus.Server.MessageContracts.Features.Spaces;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.TelemetryCollectors
{
    public interface ISpaceTelemetryCollectionCollector
    {
        Task<Dictionary<string, object>> CollectForSpace(SpaceId spaceId, CancellationToken cancellationToken);
        Task<Dictionary<string, object>> CollectForAllSpaces(CancellationToken cancellationToken);
    }
}