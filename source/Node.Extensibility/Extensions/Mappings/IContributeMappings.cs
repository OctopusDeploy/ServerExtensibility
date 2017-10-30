using System.Collections.Generic;
using Octopus.Node.Extensibility.HostServices.Mapping;

namespace Octopus.Node.Extensibility.Extensions.Mappings
{
    public interface IContributeMappings
    {
        IEnumerable<IResourceMapping> GetMappings();
    }
}