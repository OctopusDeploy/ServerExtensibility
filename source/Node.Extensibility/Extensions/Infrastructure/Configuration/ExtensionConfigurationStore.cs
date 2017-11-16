using System.Collections.Generic;
using Octopus.Client.Extensibility.Extensions.Infrastructure.Configuration;
using Octopus.Data.Storage.Configuration;
using Octopus.Node.Extensibility.Extensions.Mappings;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationStore<TConfiguration, TResource> : ConfigurationDocumentStore<TConfiguration, TResource>, IExtensionConfigurationStore, IContributeMappings
        where TConfiguration : ExtensionConfigurationDocument
        where TResource : ExtensionConfigurationResource
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

        public abstract IEnumerable<IResourceMapping> GetMappings();

        public virtual void SetIsEnabled(bool isEnabled)
        {
            SetProperty(doc => doc.IsEnabled = isEnabled);
        }
    }
}