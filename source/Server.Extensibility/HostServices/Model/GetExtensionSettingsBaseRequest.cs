using System;
using Octopus.Server.MessageContracts;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public class GetExtensionSettingsBaseRequest<TRequest, TId, TValues> : IRequest<TRequest, GetExtensionSettingsResponse<TValues>>
        where TRequest : GetExtensionSettingsBaseRequest<TRequest, TId, TValues>
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