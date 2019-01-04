using Octopus.Server.Extensibility.HostServices.Model.Projects;

namespace Octopus.Server.Extensibility.Extensions.Model.Projects
{
    public interface IContributeWorkItemsToReleases
    {
        DeploymentActionPackage GetDeploymentAction(string projectId);
    }
}