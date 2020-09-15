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
        TResource GetBody<TResource>(RequestBodyRegistration<TResource> requestBodyRegistration);

        Task<IOctoResponseProvider> HandleAsync(
            Func<Task<IOctoResponseProvider>> onSuccess);

        Task<IOctoResponseProvider> HandleAsync<T>(
            IResponderParameter<T> parameter,
            Func<T, Task<IOctoResponseProvider>> onSuccess);

        Task<IOctoResponseProvider> HandleAsync<T1, T2>(
            IResponderParameter<T1> parameter1,
            IResponderParameter<T2> parameter2,
            Func<T1, T2, Task<IOctoResponseProvider>> onSuccess);

        Task<IOctoResponseProvider> HandleAsync<T1, T2, T3>(
            IResponderParameter<T1> parameter1,
            IResponderParameter<T2> parameter2,
            IResponderParameter<T3> parameter3,
            Func<T1, T2, T3, Task<IOctoResponseProvider>> onSuccess);

        Task<IOctoResponseProvider> HandleAsync<T1, T2, T3, T4>(
            IResponderParameter<T1> parameter1,
            IResponderParameter<T2> parameter2,
            IResponderParameter<T3> parameter3,
            IResponderParameter<T4> parameter4,
            Func<T1, T2, T3, T4, Task<IOctoResponseProvider>> onSuccess);

        Task<IOctoResponseProvider> HandleAsync<T1, T2, T3, T4, T5>(
            IResponderParameter<T1> parameter1,
            IResponderParameter<T2> parameter2,
            IResponderParameter<T3> parameter3,
            IResponderParameter<T4> parameter4,
            IResponderParameter<T5> parameter5,
            Func<T1, T2, T3, T4, T5, Task<IOctoResponseProvider>> onSuccess);
    }
}