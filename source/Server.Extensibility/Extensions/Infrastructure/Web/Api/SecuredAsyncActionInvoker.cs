using System;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class SecuredAsyncActionInvoker<TAction>
        where TAction : IAsyncApiAction
    {
        protected readonly TAction Action;

        public SecuredAsyncActionInvoker(TAction action)
        {
            Action = action;
        }

        public virtual Task ExecuteAsync(OctoContext context)
        {
            if (context.User == null)
            {
                context.Response.StatusCode = 401;
                return Task.FromResult(0);
            }

            return Action.ExecuteAsync(context);
        }
    }
}