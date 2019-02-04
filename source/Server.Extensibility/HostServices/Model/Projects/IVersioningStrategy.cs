namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IVersioningStrategy
    {
        DeploymentActionPackage DonorPackage { get; }
        string Template { get; }

    }
}