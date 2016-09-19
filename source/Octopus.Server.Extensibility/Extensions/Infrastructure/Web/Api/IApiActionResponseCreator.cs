using System;
using System.Threading.Tasks;
using Nancy;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IApiActionResponseCreator
    {
        Response BadRequest(params string[] errors);
        Response BadRequest(HttpStatusCode statusCode, params string[] errors);

        Response AsStatusCode(HttpStatusCode statusCode);
        Task<Response> AsStatusCodeAsync(HttpStatusCode statusCode);

        Response AsOctopusJson<TModel>(IResponseFormatter formatter, TModel model, HttpStatusCode statusCode = HttpStatusCode.OK);

        Response Unauthorized(Request request, params string[] errors);
    }
}