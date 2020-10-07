using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Teams
{
    public class TeamIdOrName : CaseInsensitiveStringTinyType
    {
        public TeamIdOrName(string value) : base(value)
        {
        }
    }
}