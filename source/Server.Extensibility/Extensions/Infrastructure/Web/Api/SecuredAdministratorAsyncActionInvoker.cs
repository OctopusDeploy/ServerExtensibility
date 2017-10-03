using System;
using System.Threading.Tasks;
using Nancy;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Node.Extensibility.HostServices.Authorization;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class SecuredAdministratorAsyncActionInvoker<TAction, TConfigurationStore> : WhenEnabledAsyncActionInvoker<TAction, TConfigurationStore>
        where TAction : IAsyncApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        readonly IApiActionResponseCreator responseCreator;
        private readonly Lazy<IAuthorizationChecker> authorizationChecker;

        public SecuredAdministratorAsyncActionInvoker(
            TAction action,
            TConfigurationStore configurationStore, 
            IApiActionResponseCreator responseCreator,
            Lazy<IAuthorizationChecker> authorizationChecker) : base(action, configurationStore, responseCreator)
        {
            this.responseCreator = responseCreator;
            this.authorizationChecker = authorizationChecker;
        }

        public override Task<Response> ExecuteAsync(NancyContext context, IResponseFormatter response)
        {
            if (context.CurrentUser == null ||
                !authorizationChecker.Value.IsCurrentUserAdministrator())
                return responseCreator.AsStatusCodeAsync(HttpStatusCode.Unauthorized);

            return base.ExecuteAsync(context, response);
        }
    }
}