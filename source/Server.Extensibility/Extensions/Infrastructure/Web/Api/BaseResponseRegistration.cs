using System;
using System.Collections.Generic;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class BaseResponseRegistration
    {
        protected BaseResponseRegistration(HttpStatusCode statusCode, string description)
        {
            StatusCode = statusCode;
            Description = description;
            ContentTypes = new string[0];
        }

        public HttpStatusCode StatusCode { get; }

        public string Description { get; }

        public string[] ContentTypes { get; protected set; }

        internal class WrappedResponse : IOctoResponseProvider
        {
            public WrappedResponse(OctoResponse response) => Response = response;

            public OctoResponse Response { get; private set; }

            public virtual IOctoResponseProvider WithCookie(OctoCookie cookie)
            {
                Response = Response.WithCookie(cookie);
                return this;
            }

            public virtual IOctoResponseProvider WithHeader(string name, IEnumerable<string> value)
            {
                Response = Response.WithHeader(name, value);
                return this;
            }
        }
    }
}