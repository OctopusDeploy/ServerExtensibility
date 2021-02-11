using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Feeds
{
    public class FeedIdOrName : CaseInsensitiveStringTinyType, IIdOrNameTinyType
    {
        public FeedIdOrName(string value) : base(value)
        {
        }
    }
}