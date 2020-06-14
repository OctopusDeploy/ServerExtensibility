using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class OctopusJsonRegistration<TResource> : BaseResponseRegistration
    {
        public OctopusJsonRegistration(HttpStatusCode statusCode = HttpStatusCode.OK, string description = "resource returned") : base(statusCode, description)
        {
            Type = typeof(TResource);
        }

        public IOctoResponseProvider Response(TResource model) => new WrappedResponse(new OctoDataResponse(model));
    }
}