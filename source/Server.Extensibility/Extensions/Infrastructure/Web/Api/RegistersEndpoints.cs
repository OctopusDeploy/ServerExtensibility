using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class RegistersEndpoints
    {
        public List<EndpointRegistration> Registrations { get; } = new List<EndpointRegistration>();

        protected void Add<TInvoker>(string method, string path)
            where TInvoker : IAsyncActionInvoker
        {
            Registrations.Add(new EndpointRegistration(method, path, typeof(TInvoker)));
        }

        protected void Add(string method, string path, Type invokerType)
        {
            if (!typeof(IAsyncActionInvoker).IsAssignableFrom(invokerType))
                throw new ArgumentException($"The invoker type must implement {nameof(IAsyncActionInvoker)}", nameof(invokerType));

            Registrations.Add(new EndpointRegistration(method, path, invokerType));
        }

        public class EndpointRegistration
        {
            public EndpointRegistration(string method, string path, Type invokerType)
            {
                Method = method;
                Path = path;
                InvokerType = invokerType;
            }

            public string Method { get; }
            public string Path { get; }
            public Type InvokerType { get; }
        }
    }
}