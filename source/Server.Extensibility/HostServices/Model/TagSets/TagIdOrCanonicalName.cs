using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    public class TagIdOrCanonicalName : CaseInsensitiveStringTinyType
    {
        public TagIdOrCanonicalName(string value) : base(value)
        {
        }
    }
}