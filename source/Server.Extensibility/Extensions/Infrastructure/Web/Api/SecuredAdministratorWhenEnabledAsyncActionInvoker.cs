using System;
using System.Threading.Tasks;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Server.Extensibility.HostServices.Authorization;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class
        SecuredAdministratorWhenEnabledAsyncActionInvoker<TAction, TConfigurationStore>
        : WhenEnabledAsyncActionInvoker<TAction, TConfigurationStore>, IAsyncActionInvoker
        where TAction : IAsyncApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        readonly Lazy<IAuthorizationChecker> authorizationChecker;

        public SecuredAdministratorWhenEnabledAsyncActionInvoker(
            TAction action,
            TConfigurationStore configurationStore,
            Lazy<IAuthorizationChecker> authorizationChecker) : base(action, configurationStore)
        {
            this.authorizationChecker = authorizationChecker;
        }

        public override async Task<IOctoResponseProvider?> ExecutionPrechecks(IOctoRequest request)
        {
            var veto = await base.ExecutionPrechecks(request);
            if (veto != null)
                return veto;

            if (request.User == null || !authorizationChecker.Value.IsCurrentUserAdministrator())
            {
                return new BaseResponseRegistration.WrappedResponse(new OctoUnauthorisedResponse());
            }

            return null;
        }
    }
}