using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ODCM.Server.Extensibility.HostServices.Web
{
    public interface IErrorResponseFactory
    {
        HttpResponse BadRequest(ModelValidationResult modelValidationResult);
        HttpResponse BadRequest(params string[] errors);
        HttpResponse BadRequest(HttpStatusCode statusCode, params string[] errors);
    }
}
