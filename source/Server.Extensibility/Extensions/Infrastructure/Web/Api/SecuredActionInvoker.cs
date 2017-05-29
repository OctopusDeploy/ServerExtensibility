using System;
using Nancy;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class SecuredActionInvoker<TAction, TConfigurationStore> : WhenEnabledActionInvoker<TAction, TConfigurationStore>
        where TAction : IApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        readonly IApiActionResponseCreator responseCreator;

        public SecuredActionInvoker(TAction action, TConfigurationStore configurationStore, IApiActionResponseCreator responseCreator) : 
            base(action, configurationStore, responseCreator)
        {
            this.responseCreator = responseCreator;
        }

        public override Response Execute(NancyContext context, IResponseFormatter response)
        {
            if (context.CurrentUser == null)
                return responseCreator.AsStatusCode(HttpStatusCode.Unauthorized);

            return base.Execute(context, response);
        }
    }
}