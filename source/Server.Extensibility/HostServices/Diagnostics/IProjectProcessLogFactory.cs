using System;
using Octopus.Server.MessageContracts.Features.Projects;

namespace Octopus.Server.Extensibility.HostServices.Diagnostics
{
    public interface IProjectProcessLogFactory : IProcessLogFactory<IProjectProcessLog>
    {
        IProjectProcessLog Get(ProjectId projectId, string processDescription, string logDifferentiationToken);
        IProjectProcessLog Create(ProjectId projectId, string processDescription, string logDifferentiationToken, string[]? sensitiveValues = null);
    }
}