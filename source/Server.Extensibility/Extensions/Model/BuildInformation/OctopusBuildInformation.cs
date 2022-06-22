using System;

namespace Octopus.Server.Extensibility.Extensions.Model.BuildInformation
{
    public class OctopusBuildInformation
    {
        public string BuildEnvironment { get; set; } = string.Empty;
        public string BuildNumber { get; set; } = string.Empty;
        public string? BuildUrl { get; set; }
        public string? Branch { get; set; }
        public string? VcsType { get; set; }
        public string? VcsRoot { get; set; }
        public string? VcsCommitNumber { get; set; }

        public Commit[] Commits { get; set; } = new Commit[0];
    }
}