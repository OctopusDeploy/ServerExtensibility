using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ProjectName : CaseInsensitiveStringTinyType
    {
        public ProjectName(string value) : base(value)
        {
        }
    }
}