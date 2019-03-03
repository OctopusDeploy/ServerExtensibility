using System.Collections.Generic;
using Octopus.Server.Extensibility.HostServices.Model.IssueTrackers;
using Octopus.Server.Extensibility.HostServices.Model.PackageMetadata;
using Octopus.Server.Extensibility.Resources.IssueTrackers;

namespace Octopus.Server.Extensibility.Extensions.WorkItems
{
    public interface IWorkItemLinkMapper
    {
        string IssueTrackerId { get; }

        WorkItemLink[] Map(OctopusPackageMetadata packageMetadata, IEnumerable<WorkItem> workItems);
    }
}