using System;
using System.Collections.Generic;
using Nevermore.Contracts;
using Octopus.Data.Resources;
using Octopus.Data.Storage.Configuration;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ConfigurationSettings<TConfiguration, TResource> : ConfigurationDocumentStore<TConfiguration>, IHasConfigurationSettings
        where TConfiguration : class, IId
        where TResource : IResource
    {
        protected ConfigurationSettings(IConfigurationStore configurationStore) : base(configurationStore)
        {
        }

        public abstract string Description { get; }

        public Type MetadataResourceType => typeof(TResource);

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