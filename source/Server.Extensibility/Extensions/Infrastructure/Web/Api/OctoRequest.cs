using System;
using System.Collections.Generic;
using System.IO;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class OctoRequest
    {
        public OctoRequest(string scheme,
                           bool isHttps,
                           string host,
                           string pathBase,
                           string path,
                           string protocol,
                           Stream body,
                           IDictionary<string, IEnumerable<string>> headers,
                           IDictionary<string, IEnumerable<string>> query,
                           IDictionary<string, IEnumerable<string>> form,
                           IDictionary<string, string> cookies)
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
            Form = form;
            Cookies = cookies;
        }

        public string Scheme { get; }
        public bool IsHttps { get; }
        public string Host { get; }
        public string PathBase { get; }
        public string Path { get; }
        public string Protocol { get; }
        public Stream Body { get; }
        public IDictionary<string, IEnumerable<string>> Headers { get; }
        public IDictionary<string, IEnumerable<string>> Query { get; }
        public IDictionary<string, IEnumerable<string>> Form { get; }
        public IDictionary<string, string> Cookies { get; }
    }
}