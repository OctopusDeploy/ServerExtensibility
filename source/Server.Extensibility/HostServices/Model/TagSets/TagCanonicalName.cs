using System;
using System.Text.RegularExpressions;
using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    /// <summary>
    ///     This will look something like: Customers/Enterprise or Ring/EarlyAdopter
    /// </summary>
    public class TagCanonicalName : CaseInsensitiveStringTinyType
    {
        private static readonly Regex LooksLikeANameRegex = new Regex(@"^\w+\/\w+$", RegexOptions.Compiled);

        public TagCanonicalName(string value) : base(value)
        {
            if (!LooksLikeACanonicalName(value))
                throw new ArgumentException("Value must look like a canonical tag name");
        }

        internal static bool LooksLikeACanonicalName(string s)
        {
            return LooksLikeANameRegex.IsMatch(s);
        }
    }
}