using System;
using System.Linq.Expressions;
using Octopus.Data.Resources;

namespace Octopus.Node.Extensibility.Mapping
{
    public interface IResourceMapping
    {
        Type ModelType { get; }
        Type ResourceType { get; }
    }

    public interface IResourceMapping<TResource, TModel, TContext> : IResourceMapping
        where TResource : IResource
    {
        IResourceMapping<TResource, TModel, TContext> EnrichResource(Action<TModel, TResource, TContext> callback);

        IResourceMapping<TResource, TModel, TContext> EnrichResource(Action<TModel, TResource> callback);

        IResourceMapping<TResource, TModel, TContext> EnrichModel(Action<TModel, TResource> callback);

        IResourceMapping<TResource, TModel, TContext> EnrichModel(Action<TModel, TResource, TContext> callback);

        IResourceMapping<TResource, TModel, TContext> DoNotMap<TProperty>(Expression<Func<TModel, TProperty>> propertyAccessor);

        IResourceMapping<TResource, TModel, TContext> AllowReuseExisting<TProperty>(
            Expression<Func<TModel, TProperty>> propertyAccessor);

        IResourceMapping<TResource, TModel, TContext> IncludeSubType<TResourceSub, TModelSub>(Action<IResourceMapping<TResourceSub, TModelSub, TContext>> config = null)
            where TResourceSub : class, TResource where TModelSub : class, TModel;
    }

    public interface IAcceptMappings
    {
        IResourceMapping<TResource, TModel, IResourceMappingContext> Map<TResource, TModel>()
            where TResource : class, IResource
            where TModel : class;
    }
}