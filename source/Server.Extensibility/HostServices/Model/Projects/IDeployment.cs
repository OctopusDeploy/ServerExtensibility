using System;
using System.Collections.Generic;
using Nevermore.Contracts;
using Octopus.Server.Extensibility.HostServices.Model.IssueTrackers;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IDeployment
    {
        string Id { get; }
        string Name { get; }
        DateTimeOffset Created { get; }
        bool ForcePackageDownload { get; }
        bool ForcePackageRedeployment { get; }
        string Comments { get; }
        ReferenceCollection SkipActions { get; }
        ReferenceCollection SpecificMachineIds { get; }
        ReferenceCollection ExcludedMachineIds { get; }
        bool UseGuidedFailure { get; }

        string ProjectId { get; }
        string ChannelId { get; }
        string EnvironmentId { get; }
        string TenantId { get; }

        string TaskId { get; }

        string DeploymentProcessId { get; }
        string ManifestVariableSetId { get; }

        string ProjectGroupId { get; }

        string DeployedBy { get; }

        string DeployedById { get; }

        bool FailureEncountered { get; }

        ReferenceCollection DeployedToMachineIds { get; }

        IList<WorkItem> WorkItems { get; }
    }
}