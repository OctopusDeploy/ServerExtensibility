using System;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class SecuredAsyncActionInvoker<TAction> : IAsyncActionInvoker
        where TAction : IAsyncApiAction
    {
        protected readonly TAction Action;

        public SecuredAsyncActionInvoker(TAction action)
        {
            Action = action;
        }

        public virtual Task<IOctoResponseProvider> ExecuteAsync(IOctoRequest request)
        {
            if (request.User == null)
            {
                return Task.FromResult<IOctoResponseProvider>(new BaseResponseRegistration.WrappedResponse(new OctoUnauthorisedResponse()));
            }

            return Action.ExecuteAsync(request);
        }

        public Type ActionType => typeof(TAction);
    }
}