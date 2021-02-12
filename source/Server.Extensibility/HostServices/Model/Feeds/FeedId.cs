using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Feeds
{
    public class FeedId : CaseInsensitiveStringTinyType, IIdTinyType
    {
        public FeedId(string value) : base(value)
        {
        }
    }
}