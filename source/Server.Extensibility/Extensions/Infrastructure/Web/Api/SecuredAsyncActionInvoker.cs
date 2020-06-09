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

        public virtual Task<OctoResponse> ExecuteAsync(OctoRequest request)
        {
            if (request.User == null)
            {
                return Task.FromResult<OctoResponse>(new OctoUnauthorisedResponse());
            }

            return Action.ExecuteAsync(request);
        }
    }
}