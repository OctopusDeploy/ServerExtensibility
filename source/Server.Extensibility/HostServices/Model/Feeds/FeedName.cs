using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Feeds
{
    public class FeedName : CaseInsensitiveStringTinyType
    {
        public FeedName(string value) : base(value)
        {
        }
    }
}