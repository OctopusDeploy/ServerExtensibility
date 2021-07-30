using System;
using Octopus.Server.MessageContracts;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public class GetExtensionSettingsResponse<TValues> : IResponse
        where TValues : class
    {
        public GetExtensionSettingsResponse(TValues? values)
        {
            Values = values;
        }

        public TValues? Values { get; }
    }
}