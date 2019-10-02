using Octopus.Versioning;

namespace Octopus.Server.Extensibility.HostServices.Model.BuildInformation
{
    public interface IPackageVersionBuildInformation
    {
        string PackageId { get; }
        IVersion Version { get; }
        OctopusBuildInformation OctopusBuildInformation { get; }
    }
}