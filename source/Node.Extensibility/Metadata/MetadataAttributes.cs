using System;

namespace Octopus.Node.Extensibility.Metadata
{
    //public class RequiredAttribute : Attribute
    //{ }

    public class SensitiveAttribute : Attribute
    { }

    //public class ReadOnlyAttribute : Attribute
    //{ }

    //public class DescriptionAttribute : Attribute
    //{
    //    public readonly string Description;

    //    public DescriptionAttribute(string description)
    //    {
    //        this.Description = description;
    //    }
    //}

    public class DisplayLabelAttribute : Attribute
    {
        public readonly string Label;

        public DisplayLabelAttribute(string label)
        {
            this.Label = label;
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