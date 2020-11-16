using System;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IProvideDeploymentSettings
    {
        IDeploymentSettings GetDeploymentSettings<T>(ProjectId projectId);
    }

    public interface IProvideVcsDeploymentSettings
    {
        IDeploymentSettings GetDeploymentSettings<T>(ProjectId projectId, string gitRef);
    }
}