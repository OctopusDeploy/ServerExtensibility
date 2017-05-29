using System;
using System.Threading.Tasks;
using Nancy;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class WhenEnabledAsyncActionInvoker<TAction, TConfigurationStore>
        where TAction : IAsyncApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        protected readonly TAction Action;
        protected readonly TConfigurationStore ConfigurationStore;
        readonly IApiActionResponseCreator responseCreator;

        public WhenEnabledAsyncActionInvoker(TAction action, TConfigurationStore configurationStore, IApiActionResponseCreator responseCreator)
        {
            Action = action;
            ConfigurationStore = configurationStore;
            this.responseCreator = responseCreator;
        }

        public virtual Task<Response> ExecuteAsync(NancyContext context, IResponseFormatter response)
        {
            if (!ConfigurationStore.GetIsEnabled())
                return responseCreator.AsStatusCodeAsync(HttpStatusCode.BadRequest);

            return Action.ExecuteAsync(context, response);
        }
    }
}