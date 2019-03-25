using Octopus.Server.Extensibility.HostServices.Model.PackageMetadata;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ReleaseChanges
    {
        public ReleaseChanges()
        {
            VersionMetadata = new ReleasePackageVersionMetadata[0];
        }

        public string Version { get; set; }
        public string ReleaseNotes { get; set; }
        public ReleasePackageVersionMetadata[] VersionMetadata { get; set; }
    }
}