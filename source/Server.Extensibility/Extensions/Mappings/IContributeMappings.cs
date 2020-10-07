using System;
using Octopus.Server.Extensibility.HostServices.Mapping;

namespace Octopus.Server.Extensibility.Extensions.Mappings
{
    public interface IContributeMappings
    {
        void BuildMappings(IResourceMappingsBuilder builder);
    }
}