using System;

namespace Octopus.Server.Extensibility.HostServices.Mapping
{
    public interface IResourceEnricher<in TResource, in TModel>
        where TModel : class
        where TResource : class
    {
        void EnrichResource(TModel model, TResource resource);
    }
}