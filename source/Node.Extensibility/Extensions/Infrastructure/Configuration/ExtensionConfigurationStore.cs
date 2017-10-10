using System;
using Nevermore.Contracts;
using Octopus.Data.Storage.Configuration;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationStore<TConfiguration, TResource> : ConfigurationDocumentStore<TConfiguration, TResource>, IExtensionConfigurationStore, IHasConfigurationSettings
        where TConfiguration : ExtensionConfigurationDocument
        where TResource : IId
    {
        protected ExtensionConfigurationStore(IConfigurationStore configurationStore) : base(configurationStore)
        {
        }

        public bool GetIsEnabled()
        {
            return GetProperty(doc => doc.IsEnabled);
        }

        public virtual void SetIsEnabled(bool isEnabled)
        {
            SetProperty(doc => doc.IsEnabled = isEnabled);
        }
    }
}