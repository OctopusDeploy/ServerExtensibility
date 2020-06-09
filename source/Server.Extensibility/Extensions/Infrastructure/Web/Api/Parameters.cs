using System;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api;

namespace Octopus.Server.Web.Infrastructure.Api
{
    public interface IResponderParameter
    {
        string Name { get; }
        Type Type { get; }
        string Description { get; }
        bool Required { get; }
    }

    public interface IResponderPathParameter : IResponderParameter
    {}

    public interface IResponderQueryParameter : IResponderParameter
    {}

    public interface IOptionalParameter : IResponderParameter
    {}

    public interface IRequiredParameter : IResponderParameter
    {}

    public abstract class ParameterProperty<T> : IResponderParameter
    {
        protected ParameterProperty(string name, string description, bool required)
        {
            Name = name;
            Type = typeof(T);
            Description = description;
            Required = required;
        }

        public string Name { get; }

        public Type Type { get; }

        public string Description { get; }

        public bool Required { get; }
    }

    public abstract class OptionalParameterProperty<T> : ParameterProperty<T>, IOptionalParameter
    {
        protected OptionalParameterProperty(string name, string description, bool required) : base(name, description, required)
        {
        }

        public abstract T GetValue(OctoRequest request, T defaultValue = default(T));
    }

    public abstract class RequiredParameterProperty<T> : ParameterProperty<T>, IRequiredParameter
    {
        protected RequiredParameterProperty(string name, string description) : base(name, description, true)
        {
        }

        public abstract OctoResponse GetValue(OctoRequest request, Func<T, OctoResponse> successCallback, Func<BadRequestRegistration> badRequestCallback);

        protected BadRequestRegistration BadRequestRegistration()
        {
            if (!Required)
                throw new Exception("Non-required parameters won't return a bad request result");

            return new BadRequestRegistration($"No {Name} parameter was provided.");
        }
    }

    public class PathParameterProperty<T> : OptionalParameterProperty<T>, IResponderPathParameter
    {
        public PathParameterProperty(string name, string description, bool required = true) : base(name, description, required)
        {
        }

        public override T GetValue(OctoRequest request, T defaultValue = default(T))
        {
            if (!request.HasPathParameterValue(Name))
                return defaultValue;

            return request.GetPathParameterValue<T>(Name);
        }
    }

    public class RequiredPathParameterProperty<T> : RequiredParameterProperty<T>, IResponderPathParameter
    {
        public RequiredPathParameterProperty(string name, string description) : base(name, description)
        {
        }

        public override OctoResponse GetValue(OctoRequest request, Func<T, OctoResponse> successCallback, Func<BadRequestRegistration> badRequestCallback)
        {
            if (!request.HasPathParameterValue(Name))
            {
                return badRequestCallback().Response();
            }

            var value = request.GetPathParameterValue<T>(Name);
            return successCallback(value);
        }
    }

    public class QueryParameterProperty<T> : OptionalParameterProperty<T>, IResponderQueryParameter
    {
        public QueryParameterProperty(string name, string description) : base(name, description, false)
        {
        }

        public override T GetValue(OctoRequest responder, T defaultValue = default(T))
        {
            if (!responder.HasQueryValue(Name))
                return defaultValue;

            return (T)responder.GetQueryValue<T>(Name);
        }
    }

    public class RequiredQueryParameterProperty<T> : RequiredParameterProperty<T>, IResponderQueryParameter
    {
        public RequiredQueryParameterProperty(string name, string description) : base(name, description)
        {
        }

        public override OctoResponse GetValue(OctoRequest request, Func<T, OctoResponse> successCallback, Func<BadRequestRegistration> badRequestCallback)
        {
            if (!request.HasQueryValue(Name))
            {
                return badRequestCallback().Response();
            }

            var value = request.GetQueryValue<T>(Name);
            return successCallback(value);
        }
    }
}