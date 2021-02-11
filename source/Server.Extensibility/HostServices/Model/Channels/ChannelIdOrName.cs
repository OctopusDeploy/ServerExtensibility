using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Channels
{
    public class ChannelIdOrName : CaseInsensitiveStringTinyType, IIdOrNameTinyType
    {
        public ChannelIdOrName(string value) : base(value)
        {
        }
    }
}