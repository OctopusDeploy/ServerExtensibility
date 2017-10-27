using System;
using System.Collections.Generic;
using Nevermore.Contracts;
using Octopus.Data.Storage.Configuration;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ConfigurationDocumentStore<TConfiguration, TResource> : IHasConfigurationSettings
        where TConfiguration : class, IId
        where TResource : IId
    {
        readonly IConfigurationStore configurationStore;

        protected ConfigurationDocumentStore(IConfigurationStore configurationStore)
        {
            this.configurationStore = configurationStore;
        }

        public object GetConfiguration()
        {
            var doc = configurationStore.Get<TConfiguration>(Id);
            return doc;
        }

        public void SetConfiguration(object config)
        {
            if (config is TConfiguration == false)
            {
                throw new ArgumentException($"Given config type is {config.GetType()}, but {typeof(TConfiguration)} was expected");
            }

            configurationStore.Update((TConfiguration)config);
        }

        protected abstract TConfiguration MapFromResource(TResource resource);

        protected TProperty GetProperty<TProperty>(Func<TConfiguration, TProperty> prop)
        {
            var doc = configurationStore.Get<TConfiguration>(Id);
            if (doc == null)
                throw new InvalidOperationException($"{ConfigurationSetName} configuration initialization has not executed");

            return prop(doc);
        }

        protected void SetProperty(Action<TConfiguration> callback)
        {
            var doc = configurationStore.Get<TConfiguration>(Id);
            if (doc == null)
                throw new InvalidOperationException($"{ConfigurationSetName} configuration initialization has not executed");

            callback(doc);
            configurationStore.Update(doc);
        }

        public abstract string Id { get; }

        public abstract string ConfigurationSetName { get; }

        public abstract string Description { get; }

        public Type MetadataResourceType => typeof(TResource);

        public abstract IEnumerable<ConfigurationValue> GetConfigurationValues();
    }
}