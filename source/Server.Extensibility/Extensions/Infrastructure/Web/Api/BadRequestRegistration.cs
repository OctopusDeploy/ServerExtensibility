using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class BadRequestRegistration : BaseResponseRegistration
    {
        public BadRequestRegistration(string description)
            : base(HttpStatusCode.BadRequest, description)
        {
        }

        public IOctoResponseProvider Response() => new WrappedResponse(new OctoBadRequestResponse(Description));

        public IOctoResponseProvider Response(object details) => new WrappedResponse(new OctoBadRequestWithDetailsResponse(details));

        public IOctoResponseProvider Response(params string[] errors) => new WrappedResponse(new OctoBadRequestResponse(errors));
    }
}