using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class UnauthorisedRegistration : BaseResponseRegistration, IRegistrationDescription
    {
        public string Description => "Unauthorized";

        public UnauthorisedRegistration() : base(HttpStatusCode.Unauthorized)
        {
        }

        public IOctoResponseProvider Response() => new WrappedResponse(new OctoUnauthorisedResponse());
    }
}