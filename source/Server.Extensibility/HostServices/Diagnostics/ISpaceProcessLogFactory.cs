using System;
using Octopus.Server.MessageContracts.Features.Spaces;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public interface ISpaceProcessLogFactory : IProcessLogFactory<ISpaceProcessLog>
    {
        ISpaceProcessLog Create(SpaceId spaceId, string processDescription, string logDifferentiationToken, string[]? sensitiveValues = null);
    }
}