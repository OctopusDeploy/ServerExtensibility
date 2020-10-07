using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Metadata
{
    public class Metadata
    {
        public List<TypeMetadata> Types { get; set; } = new List<TypeMetadata>();
        public string? Description { get; set; }
    }
}