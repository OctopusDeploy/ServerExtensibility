using Octopus.Server.Extensibility.HostServices.Model.Environments;

namespace Octopus.Server.Extensibility.HostServices.Domain.Environments
{
    public interface IDeploymentEnvironmentStore
    {
        IDeploymentEnvironment GetDeploymentEnvironment(string id);
    }
}