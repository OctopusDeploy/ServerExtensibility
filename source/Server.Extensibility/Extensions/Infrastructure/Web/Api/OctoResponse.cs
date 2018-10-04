using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Primitives;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class OctoResponse
    {
        public int StatusCode { get; set; }
        public Stream Body { get; set; }
        public IDictionary<string, StringValues> Headers { get; set; }

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

        public virtual OctoResponse WithHeader(string name, StringValues value)
        {
            Headers[name] = value;
            return this;
        }

        public virtual void BadRequest(params string[] errors)
        {
            
        }
    }
}