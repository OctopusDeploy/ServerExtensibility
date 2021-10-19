using System;
using System.Threading.Tasks;
using Octopus.Server.Extensibility.Results;
using Octopus.Server.MessageContracts.Features.BuildInformation;
using Octopus.Server.MessageContracts.Features.IssueTrackers;

namespace Octopus.Server.Extensibility.Extensions.WorkItems
{
    public interface IWorkItemLinkMapper
    {
        string CommentParser { get; }
        Task<bool> IsEnabled();
        Task<IResultFromExtension<WorkItemLink[]>> Map(OctopusBuildInformation buildInformation);
    }
}