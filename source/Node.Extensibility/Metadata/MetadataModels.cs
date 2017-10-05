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
    }


    public class TypeMetadata
    {
        public TypeMetadata()
        {
            Properties = new List<PropertyMetadata>();
        }

        public string Name { get; set; }

        public List<PropertyMetadata> Properties { get; set; }
    }

    public class PropertyMetadata
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public DisplayInfo DisplayInfo { get; set; }
    }

    public class DisplayInfo
    {
        public bool Required { get; set; }

        public bool Sensitive { get; set; }

        public string Label { get; set; }

        public string Description { get; set; }

        public OptionsMetadata Options { get; set; }

        public ListApiMetadata ListApi { get; set; }
    }


    public class OptionsMetadata
    {
        public bool MultiSelect { get; set; }

        public Dictionary<string, string> Values { get; set; }
    }

    public class ListApiMetadata
    {
        public bool MultiSelect { get; set; }
    }
}