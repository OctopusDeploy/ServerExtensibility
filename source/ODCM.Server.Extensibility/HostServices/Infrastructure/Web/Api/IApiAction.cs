using Microsoft.AspNetCore.Http;

namespace ODCM.Server.Extensibility.HostServices.Infrastructure.Web.Api
{
    public interface IApiAction
    {
        HttpResponse Execute(HttpContext context, IResponseFormatter response);
    }
}