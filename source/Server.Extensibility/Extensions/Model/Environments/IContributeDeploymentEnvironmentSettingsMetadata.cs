using System;
using System.Collections.Generic;
using Octopus.Server.Extensibility.Metadata;

namespace Octopus.Server.Extensibility.Extensions.Model.Environments
{
    public interface IContributeDeploymentEnvironmentSettingsMetadata
    {
        string ExtensionId { get; }
        string ExtensionName { get; }
        IAsyncEnumerable<PropertyMetadata> Properties { get; }
    }
}