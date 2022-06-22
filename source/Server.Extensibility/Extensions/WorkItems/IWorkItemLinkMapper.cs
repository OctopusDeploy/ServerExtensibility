using System;
using Octopus.Server.Extensibility.Extensions.Model.BuildInformation;
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