using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public abstract class BaseResponseRegistration
    {
        protected BaseResponseRegistration(HttpStatusCode statusCode, string description)
        {
            StatusCode = statusCode;
            Description = description;
        }

        public HttpStatusCode StatusCode { get; }

        public string Description { get; }

        public Type Type { get; protected set; }

        public string[] ContentTypes { get; protected set; }

        protected class WrappedResponse : IOctoResponseProvider
        {
            public WrappedResponse(OctoResponse response) => Response = response;

            public OctoResponse Response { get; }
        }
    }

    public class BadRequestRegistration : BaseResponseRegistration
    {
        public BadRequestRegistration(string description)
            : base(HttpStatusCode.BadRequest, description)
        {

        }

        public IOctoResponseProvider Response() => new WrappedResponse(new OctoBadRequestResponse(Description));

        public IOctoResponseProvider Response(object details) => new WrappedResponse(new OctoBadRequestWithDetailsResponse(details));

        public IOctoResponseProvider Response(params string[] errors) => new WrappedResponse(new OctoBadRequestResponse(errors));
    }
    
    public class OctopusJsonRegistration<TResource> : BaseResponseRegistration
    {
        public OctopusJsonRegistration(HttpStatusCode statusCode, string description) : base(statusCode, description)
        {
            Type = typeof(TResource);
        }

        public IOctoResponseProvider Response(object model) => new WrappedResponse(new OctoDataResponse(model));
    }
    
    public static class OctoResponseProviderExtensionMethods
    {
        public static IOctoResponseProvider WithHeader(this IOctoResponseProvider responseProvider, string header, string value)
            => new WrappedResponse(responseProvider.Response.WithHeader(header, new []{ value }));

        private class WrappedResponse : IOctoResponseProvider
        {
            public WrappedResponse(OctoResponse response) => Response = response;

            public OctoResponse Response { get; }
        }
    }
}