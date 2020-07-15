using System;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public interface IProvideDeploymentEnvironmentSettingsValues
    {
        T GetSettings<T>(string extensionId, string deploymentEnvironmentId);
    }
}