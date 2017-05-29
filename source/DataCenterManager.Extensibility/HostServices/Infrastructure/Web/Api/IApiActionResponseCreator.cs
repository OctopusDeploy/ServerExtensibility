using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ODCM.Server.Extensibility.HostServices.Infrastructure.Web.Api
{
    public interface IApiActionResponseCreator
    {
        HttpResponse BadRequest(ModelValidationResult modelValidationResult);
        HttpResponse BadRequest(params string[] errors);
        HttpResponse BadRequest(HttpStatusCode statusCode, params string[] errors);

        HttpResponse AsStatusCode(HttpStatusCode statusCode);
        Task<HttpResponse> AsStatusCodeAsync(HttpStatusCode statusCode);

        HttpResponse AsOctopusJson<TModel>(IResponseFormatter formatter, TModel model, HttpStatusCode statusCode = HttpStatusCode.OK);

        HttpResponse Unauthorized(HttpRequest request, params string[] errors);
    }
}