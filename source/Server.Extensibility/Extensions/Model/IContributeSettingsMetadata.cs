using System;
using System.Collections.Generic;
using Octopus.Server.Extensibility.Metadata;

namespace Octopus.Server.Extensibility.Extensions.Model
{
    public interface IContributeSettingsMetadata
    {
        string ExtensionId { get; }
        string ExtensionName { get; }

        List<PropertyMetadata> Properties { get; }
        
        Type Resource { get; }
        Type Model { get; }
        
    }
}