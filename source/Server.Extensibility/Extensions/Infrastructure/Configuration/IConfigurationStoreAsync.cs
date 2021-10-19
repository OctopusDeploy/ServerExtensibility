using System;
using System.Threading;
using System.Threading.Tasks;
using Octopus.Data.Model.Configuration;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IConfigurationStoreAsync
    {
        Task<TDocument?> Get<TDocument>(string id, CancellationToken cancellationToken) where TDocument : ConfigurationDocument;

        Task Create<TDocument>(TDocument document, CancellationToken cancellationToken) where TDocument : ConfigurationDocument;

        Task Update<TDocument>(TDocument document, CancellationToken cancellationToken) where TDocument : ConfigurationDocument;

        Task Delete<TDocument>(TDocument document, CancellationToken cancellationToken) where TDocument : ConfigurationDocument;

        Task DeleteById<TDocument>(string documentId, CancellationToken cancellationToken) where TDocument : ConfigurationDocument;

        Task CreateOrUpdate<TDocument>(string id, Action<TDocument> assignPropertiesCallback, CancellationToken cancellationToken) where TDocument : ConfigurationDocument, new();
    }
}