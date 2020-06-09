using System.Collections.Generic;
using System.IO;
using System.Security.Principal;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class OctoRequest
    {
        string Scheme { get; }
        bool IsHttps { get; }
        string Host { get; }
        string PathBase { get; }
        string Path { get; }
        string Protocol { get; }
        IDictionary<string, IEnumerable<string>> Headers { get; }
        IDictionary<string, IEnumerable<string>> Form { get; }
        IDictionary<string, string> Cookies { get; }
        public virtual IPrincipal User { get; }

        internal abstract T GetQueryValue<T>(string queryParameter);
        internal abstract bool HasQueryValue(string queryParameter);
        internal abstract T GetPathParameterValue<T>(string pathParameter);
        internal abstract bool HasPathParameterValue(string pathParameter);
        internal abstract T GetBody<T>();
    }
}