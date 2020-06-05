using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.TagSets
{
    public class TagId : CaseInsensitiveStringTinyType
    {
        public TagId(string value) : base(value)
        {
        }
    }
}