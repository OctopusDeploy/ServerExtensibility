using System;
using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IExtensionConfigurationStoreAsync
    {
        Task<bool> GetIsEnabled(CancellationToken cancellationToken);
        Task SetIsEnabled(bool isEnabled, CancellationToken cancellationToken);
    }

    public interface IExtensionConfigurationStoreAsync<TConfiguration> : IConfigurationDocumentStoreAsync<TConfiguration>,
                                                                    IExtensionConfigurationStoreAsync
        where TConfiguration : ExtensionConfigurationDocument, new()
    {
    }
}