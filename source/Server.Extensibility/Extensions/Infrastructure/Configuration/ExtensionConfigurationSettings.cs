using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class
        ExtensionConfigurationSettings<TConfiguration, TResource, TDocumentStore> : ConfigurationSettings<TConfiguration
            , TResource, TDocumentStore>
        where TConfiguration : ExtensionConfigurationDocument, new()
        where TResource : ExtensionConfigurationResource
        where TDocumentStore : IConfigurationDocumentStore<TConfiguration>
    {
        protected ExtensionConfigurationSettings(TDocumentStore configurationDocumentStore) : base(
            configurationDocumentStore)
        {
        }
    }
}