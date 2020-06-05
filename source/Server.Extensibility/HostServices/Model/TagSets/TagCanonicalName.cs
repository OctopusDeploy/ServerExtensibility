using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    public class TagCanonicalName : CaseInsensitiveStringTinyType
    {
        public TagCanonicalName(string value) : base(value)
        {
        }
    }
}