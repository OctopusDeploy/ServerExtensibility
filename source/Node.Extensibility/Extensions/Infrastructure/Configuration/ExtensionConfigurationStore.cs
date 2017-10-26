using System;
using Nevermore.Contracts;
using Octopus.Data.Resources;
using Octopus.Data.Storage.Configuration;
using Octopus.Node.Extensibility.Extensions.Mappings;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationStore<TConfiguration, TResource> : ConfigurationDocumentStore<TConfiguration, TResource>, IExtensionConfigurationStore, IContributeMappings
        where TConfiguration : ExtensionConfigurationDocument
        where TResource : IId
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

        public abstract IResourceMapping GetMapping();

        public virtual void SetIsEnabled(bool isEnabled)
        {
            SetProperty(doc => doc.IsEnabled = isEnabled);
        }
    }
}