
namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class VersioningStrategy
    {
        public DeploymentActionPackage DonorPackage { get; set; }
        public string Template { get; set; }
    }
}