using System;
using Octopus.Server.MessageContracts.Features.DeploymentEnvironments;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public class GetDeploymentEnvironmentExtensionSettingsRequest<TValues> : GetExtensionSettingsBaseRequest<GetDeploymentEnvironmentExtensionSettingsRequest<TValues>, DeploymentEnvironmentIdOrName, GetExtensionSettingsResponse<TValues>>
        where TValues : class
    {
        public GetDeploymentEnvironmentExtensionSettingsRequest(string extensionId, DeploymentEnvironmentIdOrName spaceIdOrName) : base(extensionId, spaceIdOrName)
        {
        }
    }
}