using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Channels
{
    public class ChannelName : CaseInsensitiveStringTinyType
    {
        public ChannelName(string value) : base(value)
        {
        }
    }
}