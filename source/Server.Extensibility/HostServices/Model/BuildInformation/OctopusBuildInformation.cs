using Octopus.Server.Extensibility.HostServices.Model.IssueTrackers;

namespace Octopus.Server.Extensibility.HostServices.Model.BuildInformation
{
    public class OctopusBuildInformation
    {
        public OctopusBuildInformation()
        {
            Commits = new Commit[0];
        }

        public string BuildEnvironment { get; set; }
        public string BuildNumber { get; set; }
        public string BuildUrl { get; set; }
        public string Branch { get; set; }
        public string VcsType { get; set; }
        public string VcsRoot { get; set; }
        public string VcsCommitNumber { get; set; }

        public Commit[] Commits { get; set; }
    }
}