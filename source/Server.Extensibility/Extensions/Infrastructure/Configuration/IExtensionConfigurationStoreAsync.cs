using System;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IExtensionConfigurationStoreAsync
    {
        Task<bool> GetIsEnabled();
        Task SetIsEnabled(bool isEnabled);
    }

    public interface IExtensionConfigurationStoreAsync<TConfiguration> : IConfigurationDocumentStoreAsync<TConfiguration>,
                                                                    IExtensionConfigurationStoreAsync
        where TConfiguration : ExtensionConfigurationDocument, new()
    {
    }
}