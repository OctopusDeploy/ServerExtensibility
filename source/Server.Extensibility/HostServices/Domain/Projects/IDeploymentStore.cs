using System;
using Octopus.Server.Extensibility.HostServices.Model.Projects;

namespace Octopus.Server.Extensibility.HostServices.Domain.Projects
{
    public interface IDeploymentStore : IStore<IDeployment>
    {
    }
}