using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class UnauthorisedRegistration : BaseResponseRegistration, IRegistrationDescription
    {
        public UnauthorisedRegistration() : base(HttpStatusCode.Unauthorized)
        {
        }

        public string Description => "Unauthorized";

        public IOctoResponseProvider Response()
        {
            return new WrappedResponse(new OctoUnauthorisedResponse());
        }
    }
}