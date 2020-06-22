using System.Security.Principal;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class OctoContext
    {
        protected OctoContext(OctoRequest request, OctoResponse response, IPrincipal? user = null)
        {
            Request = request;
            Response = response;
            User = user;
        }

        public virtual OctoRequest Request { get; }
        public virtual OctoResponse Response { get; }
        public virtual IPrincipal? User { get; }
    }
}