using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Node.Extensibility.Extensions.Mappings
{
    public interface IContributeMappings
    {
        void BuildMappings(IResourceMappingsBuilder builder);
    }
}