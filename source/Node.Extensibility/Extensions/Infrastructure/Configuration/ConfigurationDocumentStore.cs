using System;
using Nevermore.Contracts;
using Octopus.Data.Storage.Configuration;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ConfigurationDocumentStore<TConfiguration>
        where TConfiguration : class, IId
    {
        readonly IConfigurationStore configurationStore;

        protected ConfigurationDocumentStore(IConfigurationStore configurationStore)
        {
            this.configurationStore = configurationStore;
        }

        public abstract string Id { get; }

        public abstract string ConfigurationSetName { get; }

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
            OnConfigurationChanged();
        }

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
            OnConfigurationChanged();
        }

        protected virtual void OnConfigurationChanged()
        { }
    }
}