using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    /// <summary>
    ///     This will look something like: TagSet-1/Tag-1
    /// </summary>
    public class TagCanonicalId : CaseInsensitiveStringTinyType
    {
        public TagCanonicalId(string value) : base(value)
        {
            if (!TagCanonicalIdOrName.LooksLikeACanonicalIdOrName(value))
                throw new ArgumentException("Value must look like a canonical tag ID");
        }
    }
}