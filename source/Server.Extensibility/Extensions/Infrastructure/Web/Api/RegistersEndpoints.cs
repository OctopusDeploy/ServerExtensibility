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

        public class EndpointRegistration
        {
            public EndpointRegistration(string method, string path, Func<IOctoRequest, Task<IOctoResponseProvider>> handler)
            {
                Method = method;
                Path = path;
                Handler = handler;
            }

            public string Method { get; }
            public string Path { get; }
            public Func<IOctoRequest, Task<IOctoResponseProvider>> Handler { get; }
        }
    }
}