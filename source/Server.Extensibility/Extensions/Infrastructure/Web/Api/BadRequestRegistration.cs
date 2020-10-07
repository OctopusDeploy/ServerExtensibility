using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class BadRequestRegistration : BaseResponseRegistration, IRegistrationDescription
    {
        public BadRequestRegistration(string description)
            : base(HttpStatusCode.BadRequest)
        {
            Description = description;
        }

        public string Description { get; }

        public IOctoResponseProvider Response()
        {
            return new WrappedResponse(new OctoBadRequestResponse(Description));
        }

        public IOctoResponseProvider Response(object details)
        {
            return new WrappedResponse(new OctoBadRequestWithDetailsResponse(details));
        }

        public IOctoResponseProvider Response(params string[] errors)
        {
            return new WrappedResponse(new OctoBadRequestResponse(errors));
        }
    }
}