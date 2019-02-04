namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IAutoDeployReleaseOverride
    {
        string EnvironmentId { get; }
        string TenantId { get; }
        string ReleaseId { get; }
    }
}