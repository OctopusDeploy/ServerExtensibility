using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IExtensionConfigurationStore
    {
        bool GetIsEnabled();
        void SetIsEnabled(bool isEnabled);
    }
}