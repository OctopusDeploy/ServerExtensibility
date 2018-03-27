using System;
using System.Linq.Expressions;

namespace Octopus.Node.Extensibility.HostServices.Mapping
{
    public interface IResourceMappingBuilder<TResource, TModel>
        where TModel : class
        where TResource : class
    {
        IResourceMappingBuilder<TResource, TModel> EnrichResource(Action<TModel, TResource> callback);

        IResourceMappingBuilder<TResource, TModel> EnrichResource<TResourceEnricher>() 
            where TResourceEnricher : IResourceEnricher<TModel, TResource>;

        IResourceMappingBuilder<TResource, TModel> EnrichModel(Action<TModel, TResource> callback);

        IResourceMappingBuilder<TResource, TModel> EnrichModel<TModelEnricher>() 
            where TModelEnricher : IModelEnricher<TModel, TResource>;

        IResourceMappingBuilder<TResource, TModel> DoNotMap<TProperty>(Expression<Func<TModel, TProperty>> propertyAccessor);

        IResourceMappingBuilder<TResource, TModel> AllowReuseExisting<TProperty>(
            Expression<Func<TModel, TProperty>> propertyAccessor);

        IResourceMappingBuilder<TResource, TModel> IncludeSubType<TResourceSub, TModelSub>()
            where TResourceSub : class, TResource where TModelSub : class, TModel;
    }
}