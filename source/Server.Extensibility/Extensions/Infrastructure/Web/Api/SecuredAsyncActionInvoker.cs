using System;
using System.Threading.Tasks;
using Nancy;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class SecuredAsyncActionInvoker<TAction, TConfigurationStore> : WhenEnabledAsyncActionInvoker<TAction, TConfigurationStore>
        where TAction : IAsyncApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        readonly IApiActionResponseCreator responseCreator;

        public SecuredAsyncActionInvoker(TAction action, TConfigurationStore configurationStore, IApiActionResponseCreator responseCreator) : base(action, configurationStore, responseCreator)
        {
            this.responseCreator = responseCreator;
        }

        public override Task<Response> ExecuteAsync(NancyContext context, IResponseFormatter response)
        {
            if (context.CurrentUser == null)
                return responseCreator.AsStatusCodeAsync(HttpStatusCode.Unauthorized);

            return base.ExecuteAsync(context, response);
        }
    }
}