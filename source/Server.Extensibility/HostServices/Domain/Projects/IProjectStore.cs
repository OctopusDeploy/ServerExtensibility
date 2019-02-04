using Octopus.Server.Extensibility.HostServices.Model.Projects;

namespace Octopus.Server.Extensibility.HostServices.Domain.Projects
{
    public interface IProjectStore
    {
        IProject GetProject(string id);
    }
}