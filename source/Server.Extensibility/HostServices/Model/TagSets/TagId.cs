using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    public class TagId : CaseInsensitiveStringTinyType
    {
        public TagId(string value) : base(value)
        {
            if (!TagSetIdOrName.LooksLikeASingleTokenIdOrName(value))
                throw new ArgumentException("Value must look like a single-token Tag ID");
        }
    }
}