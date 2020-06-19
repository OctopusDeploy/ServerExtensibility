using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    public class TagName : CaseInsensitiveStringTinyType
    {
        public TagName(string value) : base(value)
        {
            if (!TagSetIdOrName.LooksLikeASingleTokenIdOrName(value))
                throw new ArgumentException("Value must look like a single-token Tag name");
        }
    }
}