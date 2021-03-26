using System;
using Octopus.Server.Extensibility.Results;
using Octopus.Server.MessageContracts.BuildInformation;
using Octopus.Server.MessageContracts.IssueTrackers;

namespace Octopus.Server.Extensibility.Extensions.WorkItems
{
    public interface IWorkItemLinkMapper
    {
        string CommentParser { get; }
        bool IsEnabled { get; }

        IResultFromExtension<WorkItemLink[]> Map(OctopusBuildInformation buildInformation);
    }
}