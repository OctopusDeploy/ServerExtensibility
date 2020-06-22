using Newtonsoft.Json;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ReleaseCreationStrategy
    {
        [JsonConstructor]
        public ReleaseCreationStrategy(DeploymentActionPackage releaseCreationPackage, string channelId)
        {
            ReleaseCreationPackage = releaseCreationPackage;
            ChannelId = channelId;
        }

        public DeploymentActionPackage ReleaseCreationPackage { get; set; }

        public string ChannelId { get; set; }
    }
}