using System;
using System.Collections.Generic;
using Octopus.Server.Extensibility.HostServices.Model.IssueTrackers;
using Octopus.Server.Extensibility.HostServices.Model.Variables;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IRelease
    {
        string Id { get; }

        string ProjectId { get; }
        string ChannelId { get; }

        string Version { get; }
        DateTimeOffset Assembled { get; }

        string ReleaseNotes { get; }
        IList<WorkItem> WorkItems { get; }
        
        string ProjectVariableSetSnapshotId { get; }
        string ProjectDeploymentProcessSnapshotId { get; }
        List<LibraryVariableSetSnapshot> LibraryVariableSetSnapshots { get; }
        List<PackageStepVersion> SelectedPackages { get; }
    }
}