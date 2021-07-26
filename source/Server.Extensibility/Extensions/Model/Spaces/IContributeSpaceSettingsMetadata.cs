using System.Collections.Generic;
using Octopus.Server.Extensibility.Metadata;

namespace Octopus.Server.Extensibility.Extensions.Model.Spaces
{
    public interface IContributeSpaceSettingsMetadata
    {
        string ExtensionId { get; }
        string ExtensionName { get; }

        List<PropertyMetadata> Properties { get; }
    }
}