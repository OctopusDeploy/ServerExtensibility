using System.Collections.Generic;
using System.IO;
using System.Security.Principal;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class OctoRequest
    {
        public abstract string Scheme { get; }
        public abstract bool IsHttps { get; }
        public abstract string Host { get; }
        public abstract string PathBase { get; }
        public abstract string Path { get; }
        public abstract string Protocol { get; }
        public abstract IDictionary<string, IEnumerable<string>> Headers { get; }
        public abstract IDictionary<string, IEnumerable<string>> Form { get; }
        public abstract IDictionary<string, string> Cookies { get; }
        public virtual IPrincipal User { get; }

        internal abstract T GetQueryValue<T>(string queryParameter);
        internal abstract bool HasQueryValue(string queryParameter);
        internal abstract T GetPathParameterValue<T>(string pathParameter);
        internal abstract bool HasPathParameterValue(string pathParameter);
        internal abstract T GetBody<T>();
    }
}