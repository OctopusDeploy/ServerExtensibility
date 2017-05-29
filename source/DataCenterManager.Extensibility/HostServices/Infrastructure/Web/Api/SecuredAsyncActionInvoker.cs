using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;

namespace ODCM.Server.Extensibility.HostServices.Infrastructure.Web.Api
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

        public override Task<HttpResponse> ExecuteAsync(HttpContext context, IResponseFormatter response)
        {
            if (context.User == null)
                return responseCreator.AsStatusCodeAsync(HttpStatusCode.Unauthorized);

            return base.ExecuteAsync(context, response);
        }
    }
}