using System;
using Nancy;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class WhenEnabledActionInvoker<TAction, TConfigurationStore>
        where TAction : IApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        protected readonly TAction Action;
        protected readonly TConfigurationStore ConfigurationStore;
        readonly IApiActionResponseCreator responseCreator;

        public WhenEnabledActionInvoker(TAction action, TConfigurationStore configurationStore, IApiActionResponseCreator responseCreator)
        {
            Action = action;
            ConfigurationStore = configurationStore;
            this.responseCreator = responseCreator;
        }

        public virtual Response Execute(NancyContext context, IResponseFormatter response)
        {
            if (!ConfigurationStore.GetIsEnabled())
                return responseCreator.AsStatusCode(HttpStatusCode.BadRequest);

            return Action.Execute(context, response);
        }
    }
}