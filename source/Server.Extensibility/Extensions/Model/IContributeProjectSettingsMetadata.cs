using System.Collections.Generic;
using Octopus.Server.Extensibility.Metadata;

namespace Octopus.Server.Extensibility.Extensions.Model
{
    public interface IContributeProjectSettingsMetadata
    {
        string ExtensionId { get; }
        List<PropertyMetadata> Properties { get; }
    }
}