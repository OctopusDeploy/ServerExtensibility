using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Metadata
{
    public class Metadata
    {
        public Metadata()
        {
            Types = new List<TypeMetadata>();
        }

        public List<TypeMetadata> Types { get; set; }

        public string Description { get; set; }
    }
}