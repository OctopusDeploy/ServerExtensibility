using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IOctoRequest
    {
        string Scheme { get; }
        bool IsHttps { get; }
        string Host { get; }
        string PathBase { get; }
        string Path { get; }
        string Protocol { get; }
        IDictionary<string, IEnumerable<string>> Headers { get; }
        IDictionary<string, string> Form { get; }
        IDictionary<string, string> Cookies { get; }
        IPrincipal User { get; }
        Task<OctoResponse> GetParameterValue<T>(IRequiredParameter<T> parameter, Func<T, Task<OctoResponse>> onSuccess);
        T GetParameterValue<T>(IOptionalParameter parameter, T defaultValue);
        T GetBody<T>();
    }
}