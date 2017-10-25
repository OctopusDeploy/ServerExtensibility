using System;
using System.Linq.Expressions;
using Octopus.Data.Resources;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IResourceMapping
    { }

    public interface IResourceMapping<TResource, TModel, TContext> : IResourceMapping
        where TResource : IResource
    {
        IResourceMapping<TResource, TModel, TContext> DoNotMap<TProperty>(Expression<Func<TModel, TProperty>> propertyAccessor);

        //enrich
    }
}