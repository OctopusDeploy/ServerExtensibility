using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class RedirectRegistration : BaseResponseRegistration
    {
        public RedirectRegistration(HttpStatusCode statusCode, string description) : base(statusCode, description)
        {
        }

        public IOctoResponseProvider Response(string url) => new WrappedResponse(new OctoRedirectResponse(url));
    }
}