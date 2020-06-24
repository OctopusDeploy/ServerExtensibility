using Newtonsoft.Json;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ReleaseCreationStrategy
    {
        public DeploymentActionPackage? ReleaseCreationPackage { get; set; }

        public string? ChannelId { get; set; }
    }
}