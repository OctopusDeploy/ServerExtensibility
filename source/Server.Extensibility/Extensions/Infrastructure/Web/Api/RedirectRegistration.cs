using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class RedirectRegistration : BaseResponseRegistration
    {
        public string Description { get; }

        public RedirectRegistration(string description) : base(HttpStatusCode.Redirect)
        {
            Description = description;
        }

        public IOctoResponseProvider Response(string url) => new WrappedResponse(new OctoRedirectResponse(url));
    }
}