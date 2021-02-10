using System;
using System.Diagnostics.CodeAnalysis;
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
        [return: NotNullIfNotNull("value")]
        public static ProjectId? ToProjectId(this string? value)
        {
            return value == null ? null : new ProjectId(value);
        }
    }
}