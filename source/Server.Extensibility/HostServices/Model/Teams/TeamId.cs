using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Teams
{
    public class TeamId : CaseInsensitiveStringTinyType, IIdTinyType
    {
        public TeamId(string value) : base(value)
        {
        }
    }
}