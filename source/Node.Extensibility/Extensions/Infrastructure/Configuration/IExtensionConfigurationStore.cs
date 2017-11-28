using Nevermore.Contracts;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IExtensionConfigurationStore
    {
        bool GetIsEnabled();
        void SetIsEnabled(bool isEnabled);
    }

    public interface IExtensionConfigurationStore<TConfiguration> : IExtensionConfigurationStore
        where TConfiguration : ExtensionConfigurationDocument
    {
        
    }
}