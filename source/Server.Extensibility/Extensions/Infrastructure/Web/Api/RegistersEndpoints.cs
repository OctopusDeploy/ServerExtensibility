using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class RegistersEndpoints
    {
        public List<EndpointRegistration> Registrations { get; } = new List<EndpointRegistration>();

        protected void Add(string method, string path, Func<IOctoRequest, Task<IOctoResponseProvider>> handler)
        {
            Registrations.Add(new EndpointRegistration(method, path, handler));
        }

        protected void Add<TInvoker>(string method, string path)
            where TInvoker : IAsyncActionInvoker
        {
            Registrations.Add(new EndpointRegistration(method, path, typeof(TInvoker)));
        }

        protected void Add(string method, string path, Type invokerType)
        {
            Registrations.Add(new EndpointRegistration(method, path, invokerType));
        }

        public class EndpointRegistration
        {
            public EndpointRegistration(string method, string path, Func<IOctoRequest, Task<IOctoResponseProvider>> handler)
            {
                Method = method;
                Path = path;
                Handler = handler;
                InvokerType = null;
            }

            public EndpointRegistration(string method, string path, Type invokerType)
            {
                Method = method;
                Path = path;
                InvokerType = invokerType;
                Handler = null;
            }

            public string Method { get; }
            public string Path { get; }
            public Type? InvokerType { get; }
            public Func<IOctoRequest, Task<IOctoResponseProvider>>? Handler { get; }
        }
    }
}