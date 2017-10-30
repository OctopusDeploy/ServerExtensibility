using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Metadata
{
    public class TypeMetadata
    {
        public TypeMetadata()
        {
            Properties = new List<PropertyMetadata>();
        }

        public string Name { get; set; }

        public List<PropertyMetadata> Properties { get; set; }
    }
}