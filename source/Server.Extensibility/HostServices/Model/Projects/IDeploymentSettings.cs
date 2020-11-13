namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IDeploymentSettings
    {
        VersioningStrategy VersioningStrategy { get; set; }
        string ReleaseNotesTemplate { get; set; }
        bool DefaultToSkipIfAlreadyInstalled { get; set; }
        DeploymentConnectivityPolicy ConnectivityPolicy { get; set; }
        string DeploymentChangesTemplate { get; set; }
        GuidedFailureMode DefaultGuidedFailureMode { get; set; }
    }
}