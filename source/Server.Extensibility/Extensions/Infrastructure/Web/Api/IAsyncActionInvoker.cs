using System;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IAsyncActionInvoker : IActionWrapper
    {
        Task<IOctoResponseProvider> ExecuteAsync(IOctoRequest request);
    }
}