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

        public virtual Task ExecuteAsync(OctoContext context)
        {
            if (!ConfigurationStore.GetIsEnabled())
            {
                context.Response.StatusCode = 400;
                return Task.FromResult(0);
            }

            return Action.ExecuteAsync(context);
        }
    }
}