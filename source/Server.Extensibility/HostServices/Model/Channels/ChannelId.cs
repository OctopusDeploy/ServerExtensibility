using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Channels
{
    public class ChannelId : CaseInsensitiveStringTinyType
    {
        public ChannelId(string value) : base(value)
        {
        }
    }
}