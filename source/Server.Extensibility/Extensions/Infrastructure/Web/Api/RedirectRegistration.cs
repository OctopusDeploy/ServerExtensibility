using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class RedirectRegistration : BaseResponseRegistration, IRegistrationDescription
    {
        public RedirectRegistration(string description) : base(HttpStatusCode.Redirect)
        {
            Description = description;
        }

        public string Description { get; }

        public IOctoResponseProvider Response(string url)
        {
            return new WrappedResponse(new OctoRedirectResponse(url));
        }
    }
}