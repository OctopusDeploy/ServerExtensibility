using Nevermore.Contracts;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IExtensionConfigurationStore
    {
        bool GetIsEnabled();
        void SetIsEnabled(bool isEnabled);
    }
}