using System.Security.Principal;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class OctoContext
    {
        public virtual OctoRequest Request { get; }
        public virtual OctoResponse Response { get; }
        public virtual IPrincipal User { get; }
    }
}