using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Metadata
{
    public class Metadata
    {
        public string Description { get; set; } = string.Empty;
        public List<TypeMetadata> Types { get; set; } = new List<TypeMetadata>();
    }
}