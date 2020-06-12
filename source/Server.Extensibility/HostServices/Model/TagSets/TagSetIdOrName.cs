using System;
using System.Linq;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    public class TagSetIdOrName : CaseInsensitiveStringTinyType
    {
        public TagSetIdOrName(string value) : base(value)
        {
            if (!LooksLikeASingleTokenIdOrName(value))
                throw new ArgumentException("Value must look like a canonical TagSet ID or name");
        }

        internal static bool LooksLikeASingleTokenIdOrName(string s)
        {
            var tokens = s.Split("/");
            if (tokens.Length != 1) return false;
            if (tokens.Any(string.IsNullOrWhiteSpace)) return false;
            return true;
        }
    }
}