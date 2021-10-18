using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Octopus.Data.Model.Configuration;
using Octopus.Server.Extensibility.HostServices.Mapping;
using Octopus.Server.MessageContracts;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ConfigurationSettingsAsync<TConfiguration, TResource, TDocumentStore> : IHasConfigurationSettingsAsync
        where TConfiguration : ConfigurationDocument, new()
        where TResource : IResource
        where TDocumentStore : IConfigurationDocumentStoreAsync<TConfiguration>
    {
        protected ConfigurationSettingsAsync(TDocumentStore configurationDocumentStore)
        {
            ConfigurationDocumentStore = configurationDocumentStore;
        }

        protected TDocumentStore ConfigurationDocumentStore { get; }

        public abstract string Id { get; }
        public abstract string ConfigurationSetName { get; }
        public abstract string Description { get; }
        public Type MetadataResourceType => typeof(TResource);

        public virtual async Task<object> GetConfiguration()
        {
            return await ConfigurationDocumentStore.GetConfiguration();
        }

        public virtual async Task SetConfiguration(object config)
        {
            await ConfigurationDocumentStore.SetConfiguration(config);
        }

        public abstract IAsyncEnumerable<IConfigurationValue> GetConfigurationValues();

        public abstract void BuildMappings(IResourceMappingsBuilder builder);
    }

    public abstract class ConfigurationSettingsAsync<TResource> : IHasAggregatedConfigurationSettingsAsync
        where TResource : IResource
    {
        public abstract string Id { get; }

        public abstract string ConfigurationSetName { get; }

        public abstract string Description { get; }

        public Type MetadataResourceType => typeof(TResource);

        public abstract IAsyncEnumerable<IConfigurationValue> GetConfigurationValues();

        public abstract Task<object> GetConfigurationResource();
    }
}