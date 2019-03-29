using Octopus.Server.Extensibility.Resources.IssueTrackers;

namespace Octopus.Server.Extensibility.HostServices.Model.PackageMetadata
{
    public class ReleasePackageVersionMetadata
    {
        public ReleasePackageVersionMetadata()
        {
            WorkItems = new WorkItemLink[0];
        }

        public string PackageId { get; set; }
        public string Version { get; set; }

        public string BuildEnvironment { get; set; }
        public string CommentParser { get; set; }
        public string BuildNumber { get; set; }
        public string BuildLink { get; set; }
        public string VcsType { get; set; }
        public string VcsRoot { get; set; }
        public string VcsCommitNumber { get; set; }
        public string VcsCommitUrl { get; set; }
        
        public WorkItemLink[] WorkItems { get; set; }
    }
}