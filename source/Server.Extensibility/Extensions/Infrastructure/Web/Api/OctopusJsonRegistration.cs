using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IRegistrationWithResource
    {
        Type ResourceType { get; }
        string GetDescription(string friendlyTypeName);
    }

    public class OctopusJsonRegistration<TResource> : BaseResponseRegistration, IRegistrationWithResource
    {
        readonly string descriptionSuffix;

        public OctopusJsonRegistration(HttpStatusCode statusCode = HttpStatusCode.OK, string descriptionSuffix = "resource returned")
            : base(statusCode)
        {
            this.descriptionSuffix = descriptionSuffix;
            ResourceType = typeof(TResource);
        }

        public Type ResourceType { get; }

        public string GetDescription(string friendlyTypeName)
        {
            return $"{friendlyTypeName} {descriptionSuffix}";
        }

        public IOctoResponseProvider Response(TResource model) => new WrappedResponse(new OctoDataResponse(model));
    }
}