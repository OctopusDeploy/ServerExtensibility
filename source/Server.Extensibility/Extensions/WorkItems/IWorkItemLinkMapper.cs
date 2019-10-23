using Octopus.Diagnostics;
using Octopus.Server.Extensibility.HostServices.Model.BuildInformation;
using Octopus.Server.Extensibility.Resources.IssueTrackers;

namespace Octopus.Server.Extensibility.Extensions.WorkItems
{
    public interface IWorkItemLinkMapper
    {
        string CommentParser { get; }
        bool IsEnabled { get; }

        SuccessOrErrorResult<WorkItemLink[]> Map(OctopusBuildInformation buildInformation, ILogWithContext log);
    }
}