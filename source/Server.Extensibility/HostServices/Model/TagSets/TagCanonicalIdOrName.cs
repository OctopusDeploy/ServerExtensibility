using System;
using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    public class TagCanonicalIdOrName : CaseInsensitiveStringTinyType
    {
        public TagCanonicalIdOrName(string value) : base(value)
        {
            if (!TagCanonicalId.LooksLikeACanonicalId(value) && !TagCanonicalName.LooksLikeACanonicalName(value))
                throw new ArgumentException("Value must look like a canonical tag ID or name");
        }
    }
}