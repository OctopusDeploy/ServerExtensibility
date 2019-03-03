using System;
using System.Collections.Generic;
using Nevermore.Contracts;
using Octopus.Server.Extensibility.HostServices.Model.PackageMetadata;
using Octopus.Server.Extensibility.HostServices.Model.Variables;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IRelease : IId, IHaveSpace
    {
        string ProjectId { get; }
        string ChannelId { get; }

        string Version { get; }
        DateTimeOffset Assembled { get; }

        string ReleaseNotes { get; }
        IList<OctopusPackageMetadata> PackageMetadata { get; }
        
        string ProjectVariableSetSnapshotId { get; }
        string ProjectDeploymentProcessSnapshotId { get; }
        List<LibraryVariableSetSnapshot> LibraryVariableSetSnapshots { get; }
        List<PackageStepVersion> SelectedPackages { get; }
    }
}