using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IResponderParameter
    {
        string Name { get; }
        Type Type { get; }
        string Description { get; }
    }

    public interface IResponderParameter<T> : IResponderParameter
    {
    }

    public interface IResponderPathParameter : IResponderParameter
    {
    }

    public interface IResponderPathParameter<T> : IResponderParameter<T>, IResponderPathParameter
    {
    }

    public interface IResponderQueryParameter : IResponderParameter
    {
    }

    public interface IResponderQueryParameter<T> : IResponderParameter<T>, IResponderQueryParameter
    {
    }

    public interface IOptionalParameter : IResponderParameter
    {
    }

    public interface IOptionalParameter<T> : IResponderParameter<T>, IOptionalParameter
    {
        T DefaultValue { get; }
    }

    public interface IRequiredParameter : IResponderParameter
    {
    }

    public interface IRequiredParameter<T> : IResponderParameter<T>, IRequiredParameter
    {
    }

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
        protected OptionalParameterProperty(string name, string description, T defaultValue = default) : base(name, description)
        {
            DefaultValue = defaultValue;
        }

        public T DefaultValue { get; }
    }

    public abstract class RequiredParameterProperty<T> : ParameterProperty<T>, IRequiredParameter<T>
    {
        protected RequiredParameterProperty(string name, string description) : base(name, description)
        {
        }
    }

    public class RequiredPathParameterProperty<T> : RequiredParameterProperty<T>, IResponderPathParameter<T>
    {
        public RequiredPathParameterProperty(string name, string description) : base(name, description)
        {
        }
    }

    public class OptionalQueryParameterProperty<T> : OptionalParameterProperty<T>, IResponderQueryParameter<T>
    {
        public OptionalQueryParameterProperty(string name, string description) : base(name, description)
        {
        }
    }

    public class RequiredQueryParameterProperty<T> : RequiredParameterProperty<T>, IResponderQueryParameter<T>
    {
        public RequiredQueryParameterProperty(string name, string description) : base(name, description)
        {
        }
    }
}