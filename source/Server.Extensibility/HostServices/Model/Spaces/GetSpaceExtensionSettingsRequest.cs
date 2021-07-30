using System;
using Octopus.Server.MessageContracts.Features.Spaces;

namespace Octopus.Server.Extensibility.HostServices.Model.Spaces
{
    public class GetSpaceExtensionSettingsRequest<TValues> : GetExtensionSettingsBaseRequest<GetSpaceExtensionSettingsRequest<TValues>, SpaceIdOrName, GetExtensionSettingsResponse<TValues>>
        where TValues : class
    {
        public GetSpaceExtensionSettingsRequest(string extensionId, SpaceIdOrName spaceIdOrName) : base(extensionId, spaceIdOrName)
        {
        }
    }
}