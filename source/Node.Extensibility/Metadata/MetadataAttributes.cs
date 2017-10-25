using System;

namespace Octopus.Node.Extensibility.Metadata
{
    public class SensitiveAttribute : Attribute
    { }

    public class DisplayLabelAttribute : Attribute
    {
        public readonly string Label;

        public DisplayLabelAttribute(string label)
        {
            Label = label;
        }
    }

    public class ListApiAttribute : Attribute
    {
        string apiEndpoint;

        public ListApiAttribute(string apiEndpoint)
        {
            this.apiEndpoint = apiEndpoint;
        }
    }

    public class MultiSelectAttribute : Attribute
    { }

    public class HasOptionsAttribute : Attribute
    { }

}