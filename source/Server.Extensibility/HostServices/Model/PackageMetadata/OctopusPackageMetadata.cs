using Octopus.Server.Extensibility.HostServices.Model.IssueTrackers;

namespace Octopus.Server.Extensibility.HostServices.Model.PackageMetadata
{
    public class OctopusPackageMetadata
    {
        public string BuildServerType { get; set; }
        public string IssueTrackerId { get; set; }
        public string BuildNumber { get; set; }
        public string BuildLink { get; set; }
        public string VcsRoot { get; set; }

        public WorkItem[] WorkItems { get; set; }
    }
}