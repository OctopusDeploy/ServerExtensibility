using System;
using System.Threading.Tasks;
using Nancy;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IAsyncApiAction
    {
        Task<Response> ExecuteAsync(NancyContext context, IResponseFormatter response);
    }
}