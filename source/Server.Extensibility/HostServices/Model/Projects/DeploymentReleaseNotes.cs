using Octopus.Server.Extensibility.HostServices.Model.PackageMetadata;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class DeploymentReleaseNotes
    {
        public DeploymentReleaseNotes()
        {
            VersionMetadata = new OctopusPackageVersionMetadata[0];
        }

        public string Version { get; set; }
        public string ReleaseNotes { get; set; }
        public OctopusPackageVersionMetadata[] VersionMetadata { get; set; }
    }
}