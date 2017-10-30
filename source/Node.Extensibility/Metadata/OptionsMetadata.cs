using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Metadata
{
    public class OptionsMetadata
    {
        public string SelectMode { get; set; }

        public Dictionary<string, string> Values { get; set; }
    }
}