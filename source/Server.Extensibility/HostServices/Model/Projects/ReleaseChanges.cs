using Octopus.Server.Extensibility.HostServices.Model.BuildInformation;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ReleaseChanges
    {
        public ReleaseChanges()
        {
            VersionBuildInformation = new ReleasePackageVersionBuildInformation[0];
        }

        public string Version { get; set; }
        public string ReleaseNotes { get; set; }
        public ReleasePackageVersionBuildInformation[] VersionBuildInformation { get; set; }
    }
}