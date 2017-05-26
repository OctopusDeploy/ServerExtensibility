using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ODCM.Server.Extensibility.HostServices.Infrastructure.Web.Api
{
    public interface IAsyncApiAction
    {
        Task<HttpResponse> ExecuteAsync(HttpContext context, IResponseFormatter response);
    }
}