namespace Octopus.Server.Extensibility.HostServices.Model.PackageMetadata
{
    public interface IPackageVersionMetadata
    {
        string PackageId { get; }
        string Version { get; }
        OctopusPackageMetadata OctopusPackageMetadata { get; }

    }
}