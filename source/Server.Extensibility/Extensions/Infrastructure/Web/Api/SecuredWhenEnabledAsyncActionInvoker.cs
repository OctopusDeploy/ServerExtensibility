using System.Threading.Tasks;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class SecuredWhenEnabledAsyncActionInvoker<TAction, TConfigurationStore> : WhenEnabledAsyncActionInvoker<TAction, TConfigurationStore>
        where TAction : IAsyncApiAction
        where TConfigurationStore : IExtensionConfigurationStore
    {

        public SecuredWhenEnabledAsyncActionInvoker(TAction action, TConfigurationStore configurationStore) : base(action, configurationStore)
        {
        }

        public override Task ExecuteAsync(OctoContext context)
        {
            if (context.User == null)
            {
                context.Response.StatusCode = 401;
                return Task.FromResult(0);
            }

            return base.ExecuteAsync(context);
        }
    }
}