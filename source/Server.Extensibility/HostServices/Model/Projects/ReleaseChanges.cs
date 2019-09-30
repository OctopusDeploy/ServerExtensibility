using Octopus.Server.Extensibility.HostServices.Model.BuildInformation;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ReleaseChanges
    {
        public ReleaseChanges()
        {
            BuildInformation = new ReleasePackageBuildInformation[0];
        }

        public string Version { get; set; }
        public string ReleaseNotes { get; set; }
        public ReleasePackageBuildInformation[] BuildInformation { get; set; }
    }
}