using System;
using Octopus.Server.MessageContracts.Features.Projects;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class GetProjectExtensionSettingsRequest<TValues> : GetExtensionSettingsBaseRequest<GetProjectExtensionSettingsRequest<TValues>, ProjectIdOrName, TValues>
        where TValues : class
    {
        public GetProjectExtensionSettingsRequest(string extensionId, ProjectIdOrName spaceIdOrName) : base(extensionId, spaceIdOrName)
        {
        }
    }
}