using System;
using System.Collections.Generic;
using System.Security.Principal;

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
        IDictionary<string, IEnumerable<string>> Form { get; }
        IDictionary<string, string> Cookies { get; }
        IPrincipal User { get; }
        OctoResponse GetQueryValue<T>(IRequiredParameter<T> parameter, Func<T, OctoResponse> onSuccess);
        T GetQueryValue<T>(IOptionalParameter parameter, T defaultValue);
        OctoResponse GetPathParameterValue<T>(IRequiredParameter<T> parameter, Func<T, OctoResponse> onSuccess);
        T GetPathParameterValue<T>(IOptionalParameter parameter, T defaultValue);
        T GetBody<T>();
    }
}