using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IContributeMappings<TResource, TModel> where TResource : IResource
    {
        IResourceMapping<TResource, TModel> GetMapping();
    }

    public interface IResourceMapping<TResource, TModel> where TResource : IResource
    {
        
    }

    public interface IResource
    { }
}