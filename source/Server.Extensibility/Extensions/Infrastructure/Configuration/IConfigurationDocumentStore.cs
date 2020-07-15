using System;
using Octopus.Data.Model.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IConfigurationDocumentStore<TConfiguration> : IConfigurationDocumentStore
        where TConfiguration : ConfigurationDocument, new()
    {
    }

    public interface IConfigurationDocumentStore
    {
        object GetConfiguration();
        void SetConfiguration(object config);
    }
}