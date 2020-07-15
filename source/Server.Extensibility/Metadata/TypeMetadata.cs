using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Metadata
{
    public class TypeMetadata
    {
        public string Name { get; set; } = string.Empty;

        public List<PropertyMetadata> Properties { get; set; } = new List<PropertyMetadata>();
    }
}