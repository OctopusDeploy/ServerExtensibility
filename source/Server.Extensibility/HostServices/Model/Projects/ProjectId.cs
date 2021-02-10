using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ProjectId : CaseInsensitiveStringTinyType
    {
        public ProjectId(string value) : base(value)
        {
        }
    }

    public static class ProjectIdExtensionMethods
    {
        public static ProjectId ToProjectId(this string value)
        {
            return new ProjectId(value);
        }
    }
}