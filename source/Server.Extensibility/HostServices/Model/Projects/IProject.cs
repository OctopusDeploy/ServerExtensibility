using System;
using System.Collections.Generic;
using Octopus.Data.Model;
using Octopus.Server.Extensibility.HostServices.Model.Tenants;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IProject : IDocument<ProjectId>, IHaveSpace
    {
        string Slug { get; }

        string Description { get; }

        bool IsDisabled { get; }

        string ProjectGroupId { get; }
        string LifecycleId { get; }
        bool AutoCreateRelease { get; }
        bool DiscreteChannelRelease { get; }

        ReferenceCollection IncludedLibraryVariableSetIds { get; }
        ReferenceCollection UsedPackages { get; }
        TenantedDeploymentMode TenantedDeploymentMode { get; }
        bool CanPerformTenantedDeployments { get; }
        bool CanPerformUntenantedDeployments { get; }

        IList<ActionTemplateParameter> Templates { get; }
        ReleaseCreationStrategy ReleaseCreationStrategy { get; }
        ISet<AutoDeployReleaseOverride> AutoDeployReleaseOverrides { get; }

        IList<ExtensionSettingsValues> ExtensionSettings { get; }
    }
}