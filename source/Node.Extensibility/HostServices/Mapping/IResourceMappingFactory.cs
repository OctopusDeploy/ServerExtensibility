
namespace Octopus.Node.Extensibility.HostServices.Mapping
{
    public interface IResourceMappingFactory
    {
        IResourceMapping<TResource, TModel, IResourceMappingContext> Create<TResource, TModel>()
            where TResource : class
            where TModel : class;
    }
}