using System;
using Newtonsoft.Json;
using Octopus.Server.Extensibility.HostServices.Model.BuildInformation;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ReleaseChanges
    {
        [JsonConstructor]
        public ReleaseChanges(string version)
        {
            Version = version;
        }

        public string Version { get; }
        public string ReleaseNotes { get; set; } = string.Empty;

        public ReleasePackageVersionBuildInformation[] VersionBuildInformation { get; set; } = Array.Empty<ReleasePackageVersionBuildInformation>();
    }
}