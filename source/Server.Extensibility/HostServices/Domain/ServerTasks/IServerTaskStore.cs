using Octopus.Server.Extensibility.HostServices.Model.ServerTasks;

namespace Octopus.Server.Extensibility.HostServices.Domain.ServerTasks
{
    public interface IServerTaskStore : IStore<IServerTask>
    {
    }
}