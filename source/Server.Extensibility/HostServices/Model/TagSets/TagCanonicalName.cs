using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    /// <summary>
    ///     This will look something like: Customers/Enterprise or Ring/EarlyAdopter
    /// </summary>
    public class TagCanonicalName : CaseInsensitiveStringTinyType
    {
        public TagCanonicalName(string value) : base(value)
        {
            if (!TagCanonicalIdOrName.LooksLikeACanonicalIdOrName(value))
                throw new ArgumentException("Value must look like a canonical tag name");

            var tokens = value.Split("/");
            TagSetName = new TagSetName(tokens[0]);
            TagName = new TagName(tokens[1]);
        }

        public TagCanonicalName(TagSetName tagSetName, TagName tagName) : base($"{tagSetName.Value}/{tagName.Value}")
        {
            TagSetName = tagSetName;
            TagName = tagName;
        }

        public TagSetName TagSetName { get; }
        public TagName TagName { get; }
    }
}