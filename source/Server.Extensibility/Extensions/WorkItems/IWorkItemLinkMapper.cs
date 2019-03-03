using Octopus.Server.Extensibility.HostServices.Model.PackageMetadata;
using Octopus.Server.Extensibility.Resources.IssueTrackers;

namespace Octopus.Server.Extensibility.Extensions.WorkItems
{
    public interface IWorkItemLinkMapper
    {
        string IssueTrackerId { get; }
        bool IsEnabled { get; }

        WorkItemLink[] Map(OctopusPackageMetadata packageMetadata);
    }
}