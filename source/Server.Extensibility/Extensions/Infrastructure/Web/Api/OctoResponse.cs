using System;
using System.Collections.Generic;
using System.IO;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class OctoResponse
    {
        public int StatusCode { get; set; }
        public Stream? Body { get; set; }
        public IDictionary<string, IEnumerable<string>> Headers { get; } = new Dictionary<string, IEnumerable<string>>();

        public virtual OctoResponse AsOctopusJson(object model)
        {
            return this;
        }

        public virtual OctoResponse Redirect(string location)
        {
            return this;
        }

        public virtual OctoResponse WithCookie(OctoCookie cookie)
        {
            return this;
        }

        public virtual OctoResponse WithHeader(string name, IEnumerable<string> value)
        {
            Headers[name] = value;
            return this;
        }

        public virtual void BadRequest(params string[] errors)
        {
        }
    }
}