using System;
using System.Collections.Generic;
using Nevermore.Contracts;
using Octopus.Data.Resources;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ConfigurationSettings<TConfiguration, TResource, TDocumentStore> : IHasConfigurationSettings
        where TConfiguration : class, IId
        where TResource : IResource
        where TDocumentStore : IConfigurationDocumentStore<TConfiguration>
    {
        protected ConfigurationSettings(TDocumentStore configurationDocumentStore)
        {
            ConfigurationDocumentStore = configurationDocumentStore;
        }

        protected TDocumentStore ConfigurationDocumentStore { get; }

        public abstract string Id { get; }
        public abstract string ConfigurationSetName { get; }
        public abstract string Description { get; }
        public Type MetadataResourceType => typeof(TResource);

        public virtual object GetConfiguration()
        {
            return ConfigurationDocumentStore.GetConfiguration();
        }

        public virtual void SetConfiguration(object config)
        {
            ConfigurationDocumentStore.SetConfiguration(config);
        }

        public abstract IEnumerable<ConfigurationValue> GetConfigurationValues();
    }

    public abstract class ConfigurationSettings<TResource> : IHasAggregatedConfigurationSettings
        where TResource : IResource
    {
        public abstract string Id { get; }

        public abstract string ConfigurationSetName { get; }

        public abstract string Description { get; }

        public Type MetadataResourceType => typeof(TResource);

        public abstract IEnumerable<ConfigurationValue> GetConfigurationValues();

        public abstract object GetConfigurationResource();
    }
}