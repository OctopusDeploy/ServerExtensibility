using System;
using System.Collections.Generic;
using System.Linq;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public enum RouteCategory
    {
        //Routes are prepended with `/api` and applicable space route
        Api,
        //Routes start from the root, used for UI/authentication
        Navigable
    }

    public abstract class RegistersEndpoints
    {
        public List<EndpointRegistration> Registrations { get; } = new List<EndpointRegistration>();

        protected void Add<TAction>(string method, string path, RouteCategory category, IEndpointInvocation invocation)
            where TAction : IAsyncApiAction
        {
            Registrations.Add(new EndpointRegistration(method, path, category, GetInvokerType(typeof(TAction), invocation)));
        }

        protected void Add(string method, string path, RouteCategory category, Type actionType, IEndpointInvocation invocation)
        {

            Registrations.Add(new EndpointRegistration(method, path, category, GetInvokerType(actionType, invocation)));
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
            public EndpointRegistration(string method, string path, RouteCategory category, Type invokerType)
            {
                Method = method;
                Path = path;
                Category = category;
                InvokerType = invokerType;
            }

            public string Method { get; }
            public string Path { get; }
            public RouteCategory Category { get; }
            public Type InvokerType { get; }
        }
    }
}