using System;
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

        public async Task<bool> GetIsEnabled()
        {
            return await GetProperty(doc => doc.IsEnabled);
        }

        public virtual async Task SetIsEnabled(bool isEnabled)
        {
            await SetProperty(doc => doc.IsEnabled = isEnabled);
        }
    }
}