using System;
using Nancy;
using Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Node.Extensibility.HostServices.Authorization;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class SecuredAdministratorActionInvoker<TAction, TConfigurationStore> : WhenEnabledActionInvoker<TAction, TConfigurationStore>
        where TAction : IApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        readonly IApiActionResponseCreator responseCreator;
        private readonly Lazy<IAuthorizationChecker> authorizationChecker;

        public SecuredAdministratorActionInvoker(
            TAction action, 
            TConfigurationStore configurationStore, 
            IApiActionResponseCreator responseCreator,
            Lazy<IAuthorizationChecker> authorizationChecker) : 
            base(action, configurationStore, responseCreator)
        {
            this.responseCreator = responseCreator;
            this.authorizationChecker = authorizationChecker;
        }

        public override Response Execute(NancyContext context, IResponseFormatter response)
        {
            if (context.CurrentUser == null ||
                !authorizationChecker.Value.IsCurrentUserAdministrator())
                return responseCreator.AsStatusCode(HttpStatusCode.Unauthorized);

            return base.Execute(context, response);
        }
    }
}