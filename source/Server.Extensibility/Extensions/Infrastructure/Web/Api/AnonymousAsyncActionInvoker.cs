using System;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class AnonymousAsyncActionInvoker<TAction> : IAsyncActionInvoker, IActionWrapper<TAction>
        where TAction : IAsyncApiAction
    {
        protected readonly TAction Action;

        public AnonymousAsyncActionInvoker(TAction action)
        {
            Action = action;
        }

        public Task<IOctoResponseProvider> ExecuteAsync(IOctoRequest request)
        {
            return Action.ExecuteAsync(request);
        }

        public Type ActionType => typeof(TAction);
    }
}