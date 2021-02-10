using System;
using System.Collections.Generic;
using Octopus.Data.Model;
using Octopus.Server.Extensibility.HostServices.Model.Environments;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IDeployment : IDocument, IHaveSpace
    {
        DateTimeOffset Created { get; }
        bool ForcePackageDownload { get; }
        bool ForcePackageRedeployment { get; }
        string Comments { get; }
        ReferenceCollection SkipActions { get; }
        ReferenceCollection SpecificMachineIds { get; }
        ReferenceCollection ExcludedMachineIds { get; }
        bool UseGuidedFailure { get; }

        ProjectId ProjectId { get; }
        string ChannelId { get; }
        DeploymentEnvironmentId EnvironmentId { get; }
        string? TenantId { get; }

        string ReleaseId { get; }

        string TaskId { get; }

        string DeploymentProcessId { get; }
        string ManifestVariableSetId { get; }

        string DeployedBy { get; }

        string DeployedById { get; }

        bool FailureEncountered { get; }

        ReferenceCollection DeployedToMachineIds { get; }

        IList<ReleaseChanges> Changes { get; }
    }
}