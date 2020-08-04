using System;
using System.Threading.Tasks;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class AnonymousWhenEnabledAsyncActionInvoker<TAction, TConfigurationStore> : IAsyncActionInvoker
        where TAction : IAsyncApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        protected readonly TAction Action;
        protected readonly TConfigurationStore ConfigurationStore;

        public AnonymousWhenEnabledAsyncActionInvoker(TAction action, TConfigurationStore configurationStore)
        {
            Action = action;
            ConfigurationStore = configurationStore;
        }

        public virtual Task<IOctoResponseProvider?> ExecutionPrechecks(IOctoRequest request)
        {
            if (!ConfigurationStore.GetIsEnabled())
            {
                return Task.FromResult<IOctoResponseProvider?>(new BaseResponseRegistration.WrappedResponse(new OctoBadRequestResponse("Extension is disabled.")));
            }

            return Task.FromResult<IOctoResponseProvider?>(null);
        }

        public async Task<IOctoResponseProvider> ExecuteAsync(IOctoRequest request)
        {
            var veto = await ExecutionPrechecks(request);
            if (veto != null)
                return veto;

            return await Action.ExecuteAsync(request);
        }

        public Type ActionType => typeof(TAction);
    }
}