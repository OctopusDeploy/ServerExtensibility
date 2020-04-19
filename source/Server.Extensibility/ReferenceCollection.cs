using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility
{
    public class ReferenceCollection : HashSet<string>
    {
        public ReferenceCollection()
            : base(StringComparer.OrdinalIgnoreCase)
        {
        }

        public ReferenceCollection(string singleValue)
            : this(new[] { singleValue })
        {
        }

        public ReferenceCollection(IEnumerable<string> values)
            : base(values ?? new string[0], StringComparer.OrdinalIgnoreCase)
        {
        }

        public void ReplaceAll(IEnumerable<string> newItems)
        {
            Clear();

            if (newItems == null) return;

            foreach (var item in newItems)
            {
                Add(item);
            }
        }

        public ReferenceCollection Clone()
        {
            return new ReferenceCollection(this);
        }

        public override string ToString()
        {
            return string.Join(", ", this);
        }

        public static ReferenceCollection One(string item)
        {
            return new ReferenceCollection { item };
        }
    }
}