using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ProjectId : CaseInsensitiveStringTinyType, IIdTinyType
    {
        public ProjectId(string value) : base(value)
        {
        }
    }
}