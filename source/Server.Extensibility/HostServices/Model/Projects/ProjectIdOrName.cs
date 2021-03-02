using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ProjectIdOrName : CaseInsensitiveStringTinyType, IIdOrNameTinyType
    {
        public ProjectIdOrName(string value) : base(value)
        {
        }
    }
}