using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Primitives;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class OctoRequest
    {
        public OctoRequest(string scheme, bool isHttps, string host, string pathBase, string path, string protocol, Stream body, IDictionary<string, StringValues> headers, IDictionary<string, StringValues> query)
        {
            Scheme = scheme;
            IsHttps = isHttps;
            Host = host;
            PathBase = pathBase;
            Path = path;
            Protocol = protocol;
            Body = body;
            Headers = headers;
            Query = query;
        }

        public string Scheme { get; }
        public bool IsHttps { get; }
        public string Host { get; }
        public string PathBase { get; }
        public string Path { get; }
        public string Protocol { get; }
        public Stream Body { get; }
        public IDictionary<string, StringValues> Headers { get; }
        public IDictionary<string, StringValues> Query { get; }
    }
}