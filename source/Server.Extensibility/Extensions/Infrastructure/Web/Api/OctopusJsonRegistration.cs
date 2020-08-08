using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class OctopusJsonRegistration<TResource> : BaseResponseRegistration
    {
        readonly string descriptionSuffix;

        public OctopusJsonRegistration(HttpStatusCode statusCode = HttpStatusCode.OK, string descriptionSuffix = "resource returned")
            : base(statusCode)
        {
            this.descriptionSuffix = descriptionSuffix;
            Type = typeof(TResource);
        }

        public Type Type { get; }

        public string GetDescription(string friendlyTypeName)
        {
            return $"{friendlyTypeName} {descriptionSuffix}";
        }

        public IOctoResponseProvider Response(TResource model) => new WrappedResponse(new OctoDataResponse(model));
    }
}