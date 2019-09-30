namespace Octopus.Server.Extensibility.HostServices.Model.BuildInformation
{
    public interface IPackageVersionBuildInformation
    {
        string PackageId { get; }
        string Version { get; }
        OctopusBuildInformation OctopusBuildInformation { get; }

    }
}