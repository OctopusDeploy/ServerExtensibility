using System;
using System.Threading.Tasks;
using Octopus.Data.Model.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IConfigurationStoreAsync
    {
        Task<TDocument?> Get<TDocument>(string id) where TDocument : ConfigurationDocument;

        Task Create<TDocument>(TDocument document) where TDocument : ConfigurationDocument;

        Task Update<TDocument>(TDocument document) where TDocument : ConfigurationDocument;

        Task Delete<TDocument>(TDocument document) where TDocument : ConfigurationDocument;

        Task DeleteById<TDocument>(string documentId) where TDocument : ConfigurationDocument;

        Task CreateOrUpdate<TDocument>(string id, Action<TDocument> assignPropertiesCallback) where TDocument : ConfigurationDocument, new();
    }
}