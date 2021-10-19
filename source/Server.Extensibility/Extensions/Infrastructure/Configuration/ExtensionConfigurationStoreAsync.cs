using System;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationStoreAsync<TConfiguration> : ConfigurationDocumentStoreAsync<TConfiguration>,
                                                                             IExtensionConfigurationStoreAsync<TConfiguration>
        where TConfiguration : ExtensionConfigurationDocument, new()
    {
        protected ExtensionConfigurationStoreAsync(IConfigurationStoreAsync configurationStore) : base(configurationStore)
        {
        }

        public async Task<bool> GetIsEnabled(CancellationToken cancellationToken)
        {
            return await GetProperty(doc => doc.IsEnabled, cancellationToken);
        }

        public virtual async Task SetIsEnabled(bool isEnabled, CancellationToken cancellationToken)
        {
            await SetProperty(doc => doc.IsEnabled = isEnabled, cancellationToken);
        }
    }
}