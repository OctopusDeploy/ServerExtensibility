using System;
using System.Linq.Expressions;

namespace Octopus.Node.Extensibility.HostServices.Mapping
{
    public interface IResourceMapping
    { }

    public interface IResourceMapping<TResource, TModel, out TContext> : IResourceMapping
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
}