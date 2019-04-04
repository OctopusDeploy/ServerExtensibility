using Octopus.Data.Storage.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationStore<TConfiguration> : ConfigurationDocumentStore<TConfiguration>, IExtensionConfigurationStore<TConfiguration>
        where TConfiguration : ExtensionConfigurationDocument, new()
    {
        protected ExtensionConfigurationStore(IConfigurationStore configurationStore) : base(configurationStore)
        {
        }

        public bool GetIsEnabled()
        {
            return GetProperty(doc => doc.IsEnabled);
        }

        public virtual void SetIsEnabled(bool isEnabled)
        {
            SetProperty(doc => doc.IsEnabled = isEnabled);
        }
    }
}