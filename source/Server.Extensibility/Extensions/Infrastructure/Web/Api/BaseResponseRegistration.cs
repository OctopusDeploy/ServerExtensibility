using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class BaseResponseRegistration
    {
        public BaseResponseRegistration(HttpStatusCode statusCode, string description)
        {
            StatusCode = statusCode;
            Description = description;
        }

        public HttpStatusCode StatusCode { get; }

        public string Description { get; }

        public Type Type { get; protected set; }

        public string[] ContentTypes { get; protected set; }
    }

    public class BadRequestRegistration : BaseResponseRegistration
    {
        public BadRequestRegistration(string description)
            : base(HttpStatusCode.BadRequest, description)
        {

        }

        public OctoResponse Response() => new OctoBadRequestResponse(Description);

        public OctoResponse Response(object details) => new OctoBadRequestWithDetailsResponse(details);

        public OctoResponse Response(params string[] errors) => new OctoBadRequestResponse(errors);
    }
}