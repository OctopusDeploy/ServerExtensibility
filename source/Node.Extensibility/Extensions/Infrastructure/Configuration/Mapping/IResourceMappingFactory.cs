using Octopus.Data.Resources;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IResourceMappingFactory
    {
        IResourceMapping<TResource, TModel, IResourceMappingContext> Create<TResource, TModel>() 
            where TResource : IResource;
    }
}