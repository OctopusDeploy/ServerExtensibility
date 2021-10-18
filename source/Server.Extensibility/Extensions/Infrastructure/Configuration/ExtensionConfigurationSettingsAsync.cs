using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class
        ExtensionConfigurationSettingsAsync<TConfiguration, TResource, TDocumentStore> : ConfigurationSettingsAsync<TConfiguration
            , TResource, TDocumentStore>
        where TConfiguration : ExtensionConfigurationDocument, new()
        where TResource : ExtensionConfigurationResource
        where TDocumentStore : IConfigurationDocumentStoreAsync<TConfiguration>
    {
        protected ExtensionConfigurationSettingsAsync(TDocumentStore configurationDocumentStore) : base(configurationDocumentStore)
        {
        }
    }
}