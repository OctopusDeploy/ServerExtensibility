using System;
using System.Threading.Tasks;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class WhenEnabledAsyncActionInvoker<TAction, TConfigurationStore>
        where TAction : IAsyncApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {
        protected readonly TAction Action;
        protected readonly TConfigurationStore ConfigurationStore;

        public WhenEnabledAsyncActionInvoker(TAction action, TConfigurationStore configurationStore)
        {
            Action = action;
            ConfigurationStore = configurationStore;
        }

        public virtual Task<OctoResponse> ExecutionPrechecks(IOctoRequest request)
        {
            if (!ConfigurationStore.GetIsEnabled())
            {
                return Task.FromResult<OctoResponse>(new OctoBadRequestResponse("Extension is disabled."));
            }

            return null;
        }

        public Task<OctoResponse> ExecuteAsync(IOctoRequest request)
        {
            var veto = ExecutionPrechecks(request);
            if (veto != null)
            {
                return veto;
            }

            return Action.ExecuteAsync(request);
        }
    }
}