using Octopus.Data.Storage.Configuration;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationStore<TConfiguration> : ConfigurationDocumentStore<TConfiguration>, IExtensionConfigurationStore<TConfiguration>
        where TConfiguration : ExtensionConfigurationDocument
    {
        protected IResourceMappingFactory ResourceMappingFactory;

        protected ExtensionConfigurationStore(IConfigurationStore configurationStore, IResourceMappingFactory factory) : base(configurationStore)
        {
            ResourceMappingFactory = factory;
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