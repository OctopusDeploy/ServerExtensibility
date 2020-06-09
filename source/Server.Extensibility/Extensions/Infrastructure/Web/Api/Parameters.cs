using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IResponderParameter
    {
        string Name { get; }
        Type Type { get; }
        string Description { get; }
    }

    public interface IResponderPathParameter : IResponderParameter
    {}

    public interface IResponderQueryParameter : IResponderParameter
    {}

    public interface IOptionalParameter : IResponderParameter
    {}
    public interface IOptionalParameter<T> : IOptionalParameter
    {}

    public interface IRequiredParameter : IResponderParameter
    {}
    public interface IRequiredParameter<T> : IRequiredParameter
    {}

    public abstract class ParameterProperty<T> : IResponderParameter
    {
        protected ParameterProperty(string name, string description)
        {
            Name = name;
            Type = typeof(T);
            Description = description;
        }

        public string Name { get; }

        public Type Type { get; }

        public string Description { get; }
    }

    public abstract class OptionalParameterProperty<T> : ParameterProperty<T>, IOptionalParameter<T>
    {
        protected OptionalParameterProperty(string name, string description) : base(name, description)
        {
        }
    }

    public abstract class RequiredParameterProperty<T> : ParameterProperty<T>, IRequiredParameter<T>
    {
        protected RequiredParameterProperty(string name, string description) : base(name, description)
        {
        }
    }

    public class PathParameterProperty<T> : OptionalParameterProperty<T>, IResponderPathParameter
    {
        public PathParameterProperty(string name, string description) : base(name, description)
        {
        }
    }

    public class RequiredPathParameterProperty<T> : RequiredParameterProperty<T>, IResponderPathParameter
    {
        public RequiredPathParameterProperty(string name, string description) : base(name, description)
        {
        }
    }

    public class QueryParameterProperty<T> : OptionalParameterProperty<T>, IResponderQueryParameter
    {
        public QueryParameterProperty(string name, string description) : base(name, description)
        {
        }
    }

    public class RequiredQueryParameterProperty<T> : RequiredParameterProperty<T>, IResponderQueryParameter
    {
        public RequiredQueryParameterProperty(string name, string description) : base(name, description)
        {
        }
    }
}