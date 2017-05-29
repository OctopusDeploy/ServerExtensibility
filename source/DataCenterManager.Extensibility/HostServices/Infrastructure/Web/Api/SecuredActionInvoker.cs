using System.Net;
using Microsoft.AspNetCore.Http;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace ODCM.Server.Extensibility.HostServices.Infrastructure.Web.Api
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

        public override HttpResponse Execute(HttpContext context, IResponseFormatter response)
        {
            if (context.User == null)
                return responseCreator.AsStatusCode(HttpStatusCode.Unauthorized);

            return base.Execute(context, response);
        }
    }
}