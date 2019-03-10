namespace Octopus.Server.Extensibility.HostServices.Model.PackageMetadata
{
    public class OctopusPackageVersionMetadata
    {
        public OctopusPackageVersionMetadata()
        {
            OctopusPackageMetadata = new OctopusPackageMetadata();
        }

        public string PackageId { get; set; }

        public string Version { get; set; }

        public OctopusPackageMetadata OctopusPackageMetadata { get; set; }
    }
}