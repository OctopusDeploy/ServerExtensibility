using System;
using System.Collections.Generic;
using Octopus.Server.Extensibility.Metadata;

namespace Octopus.Server.Extensibility.Extensions.Model.Projects
{
    public interface IContributeProjectSettingsMetadata
    {
        string ExtensionId { get; }
        string ExtensionName { get; }

        List<PropertyMetadata> Properties { get; }
    }
}