using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Feeds
{
    public class FeedIdOrName : CaseInsensitiveStringTinyType
    {
        public FeedIdOrName(string value) : base(value)
        {
        }
    }
}