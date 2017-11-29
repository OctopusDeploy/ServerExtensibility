using System.Collections.Generic;
using Octopus.Node.Extensibility.Extensions.Mappings;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationSettings<TConfiguration, TResource, TDocumentStore> : ConfigurationSettings<TConfiguration, TResource, TDocumentStore>, IContributeMappings where TConfiguration : ExtensionConfigurationDocument
        where TResource : ExtensionConfigurationResource
        where TDocumentStore : IConfigurationDocumentStore<TConfiguration>
    {
        protected IResourceMappingFactory ResourceMappingFactory;

        protected ExtensionConfigurationSettings(TDocumentStore configurationDocumentStore, IResourceMappingFactory factory) : base(configurationDocumentStore)
        {
            ResourceMappingFactory = factory;
        }

        public abstract IEnumerable<IResourceMapping> GetMappings();
    }
}