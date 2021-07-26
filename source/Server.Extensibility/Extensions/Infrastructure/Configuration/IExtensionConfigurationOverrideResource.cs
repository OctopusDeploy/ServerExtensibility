using System;
using Octopus.Server.MessageContracts;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IExtensionConfigurationOverrideResource
    {
        bool IsOverriding { get; set; }
    }
}