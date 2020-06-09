using System;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IAsyncApiAction
    {
        Task<OctoResponse> ExecuteAsync(OctoRequest request);
    }
}