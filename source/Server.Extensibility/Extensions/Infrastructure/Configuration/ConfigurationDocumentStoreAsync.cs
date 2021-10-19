using System;
using System.Threading;
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

        public async Task<object> GetConfiguration(CancellationToken cancellationToken)
        {
            var doc = await configurationStore.Get<TConfiguration>(Id, cancellationToken);
            return doc ?? new TConfiguration();
        }

        public async Task SetConfiguration(object config, CancellationToken cancellationToken)
        {
            if (config is TConfiguration == false)
                throw new ArgumentException($"Given config type is {config.GetType()}, but {typeof(TConfiguration)} was expected");

            var existingConfig = await configurationStore.Get<TConfiguration>(Id, cancellationToken);
            if (existingConfig == null)
                await configurationStore.Create((TConfiguration)config, cancellationToken);
            else
                await configurationStore.Update((TConfiguration)config, cancellationToken);

            await OnConfigurationChanged(cancellationToken);
        }

        protected async Task<TProperty> GetProperty<TProperty>(Func<TConfiguration, TProperty> prop, CancellationToken cancellationToken)
        {
            var doc = await configurationStore.Get<TConfiguration>(Id, cancellationToken);
            if (doc == null)
                throw new InvalidOperationException($"{Id} configuration initialization has not executed");

            return prop(doc);
        }

        protected async Task SetProperty(Action<TConfiguration> callback, CancellationToken cancellationToken)
        {
            var doc = await configurationStore.Get<TConfiguration>(Id, cancellationToken);
            if (doc == null)
                throw new InvalidOperationException($"{Id} configuration initialization has not executed");

            callback(doc);
            await configurationStore.Update(doc, cancellationToken);
            await OnConfigurationChanged(cancellationToken);
        }

        protected virtual async Task OnConfigurationChanged(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}