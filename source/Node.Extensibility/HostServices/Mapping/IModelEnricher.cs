namespace Octopus.Node.Extensibility.HostServices.Mapping
{
    public interface IModelEnricher<in TModel, in TResource>
        where TModel : class
        where TResource : class
    {
        void EnrichModel(TModel model, TResource resource);
    }
}