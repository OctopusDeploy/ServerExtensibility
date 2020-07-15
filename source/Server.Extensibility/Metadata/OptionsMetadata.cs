using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Metadata
{
    public class OptionsMetadata
    {
        public string SelectMode { get; set; } = string.Empty;

        public Dictionary<string, string> Values { get; set; } = new Dictionary<string, string>();
    }
}