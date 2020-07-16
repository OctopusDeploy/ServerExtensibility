using System;
using Octopus.Server.Extensibility.HostServices.Model.BuildInformation;
using Octopus.Server.Extensibility.Resources.IssueTrackers;
using Octopus.Server.Extensibility.Results;

namespace Octopus.Server.Extensibility.Extensions.WorkItems
{
    public interface IWorkItemLinkMapper
    {
        string CommentParser { get; }
        bool IsEnabled { get; }

        IResultFromExtension<WorkItemLink[]> Map(OctopusBuildInformation buildInformation);
    }
}