using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public enum RouteCategory
    {
        /// <summary>
        /// Used for extra API calls. Routes are prepended with `/api` and any applicable space route, users have to be authenticated.
        /// </summary>
        Api,
        /// <summary>
        /// Used for UI/authentication. Routes start from the root, allows anonymous access.
        /// </summary>
        Raw
    }

    public abstract class RegistersEndpoints
    {
        public List<EndpointRegistration> Registrations { get; } = new List<EndpointRegistration>();

        protected void Add<TAction>(string method, string path, RouteCategory category, IEndpointInvocation invocation)
            where TAction : IAsyncApiAction
        {
            Registrations.Add(new EndpointRegistration(method, path, category, GetInvokerType(typeof(TAction), invocation), null));
        }

        protected void Add<TAction>(string method, string path, RouteCategory category, IEndpointInvocation invocation, string description)
            where TAction : IAsyncApiAction
        {
            Registrations.Add(new EndpointRegistration(method, path, category, GetInvokerType(typeof(TAction), invocation), description));
        }

        protected void Add(string method, string path, RouteCategory category, Type actionType, IEndpointInvocation invocation, string description)
        {

            Registrations.Add(new EndpointRegistration(method, path, category, GetInvokerType(actionType, invocation), description));
        }

        static Type GetInvokerType(Type actionType, IEndpointInvocation invocation)
        {
            if (!typeof(IAsyncApiAction).IsAssignableFrom(actionType))
                throw new ArgumentException($"The action type must implement {nameof(IAsyncApiAction)}", nameof(actionType));

            var invocationType = invocation.GetType();
            if (invocationType.IsGenericType)
            {
                var invocationTypeDefinition = invocationType.GetGenericTypeDefinition();

                if (invocationTypeDefinition == typeof(AnonymousWhenEnabledEndpointInvocation<>))
                    return typeof(AnonymousWhenEnabledAsyncActionInvoker<,>).MakeGenericType(actionType, invocationType.GenericTypeArguments.Single());

                if (invocationTypeDefinition == typeof(SecuredWhenEnabledEndpointInvocation<>))
                    return typeof(SecuredWhenEnabledAsyncActionInvoker<,>).MakeGenericType(actionType, invocationType.GenericTypeArguments.Single());

                if (invocationTypeDefinition == typeof(SecuredAdministratorWhenEnabledEndpointInvocation<>))
                    return typeof(SecuredAdministratorWhenEnabledAsyncActionInvoker<,>).MakeGenericType(actionType, invocationType.GenericTypeArguments.Single());
            }
            else
            {
                if (invocation is AnonymousEndpointInvocation)
                    return typeof(AnonymousAsyncActionInvoker<>).MakeGenericType(actionType);

                if (invocation is SecuredEndpointInvocation)
                    return typeof(SecuredAsyncActionInvoker<>).MakeGenericType(actionType);
            }

            throw new ArgumentException($"Unrecognized invocation type: '{invocation.GetType()}'", nameof(invocation));
        }

        public class EndpointRegistration
        {
            public EndpointRegistration(string method, string path, RouteCategory category, Type invokerType, string description)
            {
                Method = method;
                Path = path;
                Category = category;
                InvokerType = invokerType;
                Description = description;
            }

            public string Method { get; }
            public string Path { get; }
            public RouteCategory Category { get; }
            public Type InvokerType { get; }
            public string Description { get; }
        }
    }
}