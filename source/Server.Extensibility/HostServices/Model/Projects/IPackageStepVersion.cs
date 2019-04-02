namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IPackageStepVersion
    {
        string ActionName { get; }
        string PackageReferenceName { get; }
        string Version { get; }
    }
}