using System.Collections.Generic;
using Nevermore.Contracts;
using Octopus.Server.Extensibility.HostServices.Model.Tenants;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IProject : INamedDocument, ISpaceScopedDocument
    {
        string Description { get; }

        bool IsDisabled { get; }

        string ProjectGroupId { get; }
        string LifecycleId { get; }
        bool AutoCreateRelease { get; }
        bool DiscreteChannelRelease { get; }

        ReferenceCollection IncludedLibraryVariableSetIds { get; }
        ReferenceCollection UsedPackages { get; }
        bool DefaultToSkipIfAlreadyInstalled { get; }
        TenantedDeploymentMode TenantedDeploymentMode { get; }
        bool CanPerformTenantedDeployments { get; }
        bool CanPerformUntenantedDeployments { get; }

        VersioningStrategy VersioningStrategy { get; }
        GuidedFailureMode DefaultGuidedFailureMode { get; }
        IList<ActionTemplateParameter> Templates { get; }
        ReleaseCreationStrategy ReleaseCreationStrategy { get; }
        ProjectConnectivityPolicy ProjectConnectivityPolicy { get; }
        ISet<AutoDeployReleaseOverride> AutoDeployReleaseOverrides { get; }

        List<DeploymentActionPackage> WorkItemPackages { get; }
        bool AppendWorkItemDetailsToReleaseNotes { get; }

        IList<ExtensionSettingsValues> ExtensionSettings { get; }
    }
}