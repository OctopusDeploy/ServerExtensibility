using System;
using Octopus.Server.MessageContracts;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public class GetExtensionSettingsBaseRequest<TId, TValues> : IRequest<GetExtensionSettingsBaseRequest<TId, TValues>, GetExtensionSettingsResponse<TValues>>
        where TId : class, IIdOrNameTinyType
        where TValues : class
    {
        public GetExtensionSettingsBaseRequest(string extensionId, TId idOrName)
        {
            ExtensionId = extensionId;
            IdOrName = idOrName;
        }

        public string ExtensionId { get; }
        public TId IdOrName { get; }
    }
}