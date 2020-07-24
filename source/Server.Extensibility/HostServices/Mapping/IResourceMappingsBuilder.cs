using System;

namespace Octopus.Server.Extensibility.HostServices.Mapping
{
    public interface IResourceMappingsBuilder
    {
        IResourceMappingBuilder<TResource, TModel> Map<TResource, TModel>()
            where TResource : class
            where TModel : class;
    }
}