using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class RedirectRegistration : BaseResponseRegistration
    {
        public RedirectRegistration(string description) : base(HttpStatusCode.Redirect, description)
        {
        }

        public IOctoResponseProvider Response(string url) => new WrappedResponse(new OctoRedirectResponse(url));
    }
}