using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Teams
{
    public class TeamIdOrName : CaseInsensitiveStringTinyType, IIdOrNameTinyType
    {
        public TeamIdOrName(string value) : base(value)
        {
        }
    }
}