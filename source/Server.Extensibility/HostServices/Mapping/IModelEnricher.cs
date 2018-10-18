namespace Octopus.Server.Extensibility.HostServices.Mapping
{
    public interface IModelEnricher<in TResource, in TModel>
        where TModel : class
        where TResource : class
    {
        void EnrichModel(TModel model, TResource resource);
    }
}