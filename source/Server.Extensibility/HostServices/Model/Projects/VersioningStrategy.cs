
using Newtonsoft.Json;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class VersioningStrategy
    {
        [JsonConstructor]
        public VersioningStrategy(DeploymentActionPackage donorPackage, string template)
        {
            DonorPackage = donorPackage;
            Template = template;
        }

        public DeploymentActionPackage DonorPackage { get; }
        public string Template { get; set; }
    }
}