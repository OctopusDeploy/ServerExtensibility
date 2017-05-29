using Nancy;
using Nancy.Validation;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public interface IErrorResponseFactory
    {
        Response BadRequest(ModelValidationResult modelValidationResult);
        Response BadRequest(params string[] errors);
        Response BadRequest(HttpStatusCode statusCode, params string[] errors);
    }
}