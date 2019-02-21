using Octopus.Server.Extensibility.Extensions.WorkItems;

namespace Octopus.Server.Extensibility.HostServices.Domain.WorkItems
{
    public interface IIssueTrackersProvider
    {
        IIssueTracker[] GetActiveIssueTrackers();
        IIssueTracker[] GetAllIssueTrackers();
    }
}