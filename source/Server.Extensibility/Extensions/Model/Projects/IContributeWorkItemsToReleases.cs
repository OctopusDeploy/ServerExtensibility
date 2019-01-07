using Octopus.Server.Extensibility.Resources;

namespace Octopus.Server.Extensibility.Extensions.Model.Projects
{
    public interface IContributeWorkItemsToReleases
    {
        DeploymentActionPackageResource GetDeploymentAction(string projectId);
    }
}