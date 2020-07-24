using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    public class TagSetName : CaseInsensitiveStringTinyType
    {
        public TagSetName(string value) : base(value)
        {
            if (!TagSetIdOrName.LooksLikeASingleTokenIdOrName(value))
                throw new ArgumentException("Value must look like a canonical TagSet name");
        }
    }
}