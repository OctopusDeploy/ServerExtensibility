using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class RegisterEndpoint
    {
        readonly List<EndpointRegistration> registrations = new List<EndpointRegistration>();

        public List<EndpointRegistration> Registrations => registrations;

        protected void Add(string method, string path, Action<OctoContext> handler)
        {
            Registrations.Add(new EndpointRegistration(method, path, handler));
        }

        public class EndpointRegistration
        {
            public EndpointRegistration(string method, string path, Action<OctoContext> handler)
            {
                Method = method;
                Path = path;
                Handler = handler;
            }

            public string Method { get; }
            public string Path { get; }
            public Action<OctoContext> Handler { get; }
        }
    }
}