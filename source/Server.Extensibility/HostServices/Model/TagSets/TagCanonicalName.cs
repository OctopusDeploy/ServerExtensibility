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
        }

        public TagSetName TagSetName => new TagSetName(Value.Split("/")[0]);
    }
}