using System;
using Octopus.Data.Model;

namespace Octopus.Node.Extensibility.Metadata
{
    public abstract class SelectableAttribute : Attribute
    {
        public readonly SelectMode SelectMode;

        protected SelectableAttribute(SelectMode selectMode)
        {
            SelectMode = selectMode;
        }
    }

    public class ListApiAttribute : SelectableAttribute
    {
        public readonly Href ApiEndpoint;

        public ListApiAttribute(SelectMode selectMode, Href apiEndpoint)
            : base(selectMode)
        {
            ApiEndpoint = apiEndpoint;
        }
    }

    public class HasOptionsAttribute : SelectableAttribute
    {
        public HasOptionsAttribute(SelectMode selectMode) 
            : base(selectMode)
        { }
    }

    public enum SelectMode
    {
        Single, Multiple
    }

}