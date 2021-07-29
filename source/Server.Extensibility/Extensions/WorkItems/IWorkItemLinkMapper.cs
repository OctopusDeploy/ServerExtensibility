using System;
using System.Threading;
using System.Threading.Tasks;
using Octopus.Server.Extensibility.Results;
using Octopus.Server.MessageContracts.Features.BuildInformation;
using Octopus.Server.MessageContracts.Features.IssueTrackers;
using Octopus.Server.MessageContracts.Features.Spaces;

namespace Octopus.Server.Extensibility.Extensions.WorkItems
{
    public interface IWorkItemLinkMapper
    {
        string CommentParser { get; }
        bool IsEnabled { get; }

        Task<IResultFromExtension<WorkItemLink[]>> Map(SpaceId spaceId, OctopusBuildInformation buildInformation, CancellationToken cancellationToken);
    }
}