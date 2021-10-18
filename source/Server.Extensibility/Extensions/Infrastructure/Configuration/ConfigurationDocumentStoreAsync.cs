using System;
using System.Threading.Tasks;
using Octopus.Data.Model.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ConfigurationDocumentStoreAsync<TConfiguration> : IConfigurationDocumentStoreAsync<TConfiguration>
        where TConfiguration : ConfigurationDocument, new()
    {
        readonly IConfigurationStoreAsync configurationStore;

        protected ConfigurationDocumentStoreAsync(IConfigurationStoreAsync configurationStore)
        {
            this.configurationStore = configurationStore;
        }

        public abstract string Id { get; }

        public async Task<object> GetConfiguration()
        {
            var doc = await configurationStore.Get<TConfiguration>(Id);
            return doc ?? new TConfiguration();
        }

        public async Task SetConfiguration(object config)
        {
            if (config is TConfiguration == false)
                throw new ArgumentException($"Given config type is {config.GetType()}, but {typeof(TConfiguration)} was expected");

            var existingConfig = await configurationStore.Get<TConfiguration>(Id);
            if (existingConfig == null)
                await configurationStore.Create((TConfiguration)config);
            else
                await configurationStore.Update((TConfiguration)config);

            OnConfigurationChanged();
        }

        protected async Task<TProperty> GetProperty<TProperty>(Func<TConfiguration, TProperty> prop)
        {
            var doc = await configurationStore.Get<TConfiguration>(Id);
            if (doc == null)
                throw new InvalidOperationException($"{Id} configuration initialization has not executed");

            return prop(doc);
        }

        protected async Task SetProperty(Action<TConfiguration> callback)
        {
            var doc = await configurationStore.Get<TConfiguration>(Id);
            if (doc == null)
                throw new InvalidOperationException($"{Id} configuration initialization has not executed");

            callback(doc);
            await configurationStore.Update(doc);
            OnConfigurationChanged();
        }

        protected virtual void OnConfigurationChanged()
        {
        }
    }
}