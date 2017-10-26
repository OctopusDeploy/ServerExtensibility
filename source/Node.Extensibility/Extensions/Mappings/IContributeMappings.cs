using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Node.Extensibility.Extensions.Mappings
{
    public interface IContributeMappings
    {
        IResourceMapping GetMapping();
    }
}