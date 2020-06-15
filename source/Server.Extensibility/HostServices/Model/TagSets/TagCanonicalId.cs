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

            var tokens = value.Split("/");
            TagSetId = new TagSetId(tokens[0]);
            TagId = new TagId(tokens[1]);
        }

        public TagCanonicalId(TagSetId tagSetId, TagId tagId) : base($"{tagSetId.Value}/{tagId.Value}")
        {
            TagSetId = tagSetId;
            TagId = tagId;
        }

        public TagSetId TagSetId { get; }
        public TagId TagId { get; }
    }
}