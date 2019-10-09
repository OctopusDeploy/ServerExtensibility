using Octopus.Server.Extensibility.Resources.IssueTrackers;

namespace Octopus.Server.Extensibility.HostServices.Model.BuildInformation
{
    public class ReleasePackageVersionBuildInformation
    {
        public ReleasePackageVersionBuildInformation()
        {
            WorkItems = new WorkItemLink[0];
            Commits = new CommitDetails[0];
        }

        public string PackageId { get; set; }
        public string Version { get; set; }

        public string BuildEnvironment { get; set; }
        public string BuildNumber { get; set; }
        public string BuildUrl { get; set; }
        public string Branch { get; set; }
        public string VcsType { get; set; }
        public string VcsRoot { get; set; }
        public string VcsCommitNumber { get; set; }
        public string VcsCommitUrl { get; set; }
        
        public WorkItemLink[] WorkItems { get; set; }
        public CommitDetails[] Commits { get; set; }
    }
}