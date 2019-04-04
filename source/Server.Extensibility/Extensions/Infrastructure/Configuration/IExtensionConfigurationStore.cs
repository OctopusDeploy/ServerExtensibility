
namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IExtensionConfigurationStore
    {
        bool GetIsEnabled();
        void SetIsEnabled(bool isEnabled);
    }

    public interface IExtensionConfigurationStore<TConfiguration> : IConfigurationDocumentStore<TConfiguration>, IExtensionConfigurationStore
        where TConfiguration : ExtensionConfigurationDocument, new()
    {
        
    }
}