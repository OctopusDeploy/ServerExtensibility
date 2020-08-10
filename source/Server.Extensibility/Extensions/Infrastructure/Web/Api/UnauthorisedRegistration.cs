using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class UnauthorisedRegistration : BaseResponseRegistration, IRegistrationDescription
    {
        public string Description { get; }

        public UnauthorisedRegistration(string description) : base(HttpStatusCode.Unauthorized)
        {
            Description = description;
        }

        public IOctoResponseProvider Response() => new WrappedResponse(new OctoUnauthorisedResponse());
    }
}