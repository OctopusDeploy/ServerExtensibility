using Microsoft.AspNetCore.Http;

namespace ODCM.Server.Extensibility.HostServices.Infrastructure.Web.Api
{
    public interface IApiActionModelBinder
    {
        TModel Bind<TModel>(HttpContext context);
        TModel BindAndValidate<TModel>(HttpContext context);
    }
}