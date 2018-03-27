namespace Octopus.Node.Extensibility.HostServices.Mapping
{
    public interface IResourceEnricher<in TModel, in TResource>
        where TModel : class
        where TResource : class
    {
        void EnrichResource(TModel model, TResource resource);
    }
}