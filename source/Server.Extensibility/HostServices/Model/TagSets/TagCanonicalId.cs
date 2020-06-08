using System;
using System.Text.RegularExpressions;
using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    /// <summary>
    ///     This will look something like: TagSet-1/Tag-1
    /// </summary>
    public class TagCanonicalId : CaseInsensitiveStringTinyType
    {
        private static readonly Regex LooksLikeAnIdRegex = new Regex(@"^\w+\/\w+$", RegexOptions.Compiled);

        public TagCanonicalId(string value) : base(value)
        {
            if (!LooksLikeACanonicalId(value)) throw new ArgumentException("Value must look like a canonical tag ID");
        }

        internal static bool LooksLikeACanonicalId(string s)
        {
            return LooksLikeAnIdRegex.IsMatch(s);
        }
    }
}