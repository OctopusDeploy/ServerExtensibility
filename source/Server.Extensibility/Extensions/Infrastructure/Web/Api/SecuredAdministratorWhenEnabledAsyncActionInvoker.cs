using System;
using System.Threading.Tasks;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.HostServices.Authorization;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class SecuredAdministratorWhenEnabledAsyncActionInvoker<TAction, TConfigurationStore> : WhenEnabledAsyncActionInvoker<TAction, TConfigurationStore>
        where TAction : IAsyncApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        private readonly Lazy<IAuthorizationChecker> authorizationChecker;

        public SecuredAdministratorWhenEnabledAsyncActionInvoker(
            TAction action,
            TConfigurationStore configurationStore,
            Lazy<IAuthorizationChecker> authorizationChecker) : base(action, configurationStore)
        {
            this.authorizationChecker = authorizationChecker;
        }

        public override Task<OctoResponse> ExecutionPrechecks(IOctoRequest request)
        {
            var veto = base.ExecutionPrechecks(request);
            if (veto != null)
                return veto;

            if (request.User == null ||
                !authorizationChecker.Value.IsCurrentUserAdministrator())
            {
                return Task.FromResult<OctoResponse>(new OctoUnauthorisedResponse());
            }

            return null;
        }
    }
}