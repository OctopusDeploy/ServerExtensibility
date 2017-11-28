using System.Collections.Generic;
using Octopus.Data.Storage.Configuration;
using Octopus.Node.Extensibility.Extensions.Mappings;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationSettings<TConfiguration, TResource> : ConfigurationSettings<TConfiguration, TResource>, IExtensionConfigurationSettings, IContributeMappings
        where TConfiguration : ExtensionConfigurationDocument
        where TResource : ExtensionConfigurationResource
    {
        protected IResourceMappingFactory ResourceMappingFactory;

        protected ExtensionConfigurationSettings(IConfigurationStore configurationStore, IResourceMappingFactory factory) : base(configurationStore)
        {
            ResourceMappingFactory = factory;
        }

        public abstract IEnumerable<IResourceMapping> GetMappings();
    }
}