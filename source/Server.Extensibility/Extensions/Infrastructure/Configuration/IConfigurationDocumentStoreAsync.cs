using System;
using System.Threading.Tasks;
using Octopus.Data.Model.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IConfigurationDocumentStoreAsync<TConfiguration> : IConfigurationDocumentStoreAsync
        where TConfiguration : ConfigurationDocument, new()
    {
    }

    public interface IConfigurationDocumentStoreAsync
    {
        Task<object> GetConfiguration();
        Task SetConfiguration(object config);
    }
}