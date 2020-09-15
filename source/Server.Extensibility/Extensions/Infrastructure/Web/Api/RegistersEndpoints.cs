using System;
using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public enum RouteCategory
    {
        /// <summary>
        /// Used for extra API calls. Routes are prepended with `/api` and any applicable space route, users have to be authenticated.
        /// </summary>
        Api,

        /// <summary>
        /// Used for UI/authentication. Routes start from the root, allows anonymous access.
        /// </summary>
        Raw
    }

    public abstract class RegistersEndpoints
    {
        public List<EndpointRegistration> Registrations { get; } = new List<EndpointRegistration>();

        protected void Add<TAction>(string method,
                                    string path,
                                    RouteCategory category,
                                    IEndpointInvocation invocation,
                                    string? description,
                                    string? tag)
            where TAction : IAsyncApiAction
        {
            Registrations.Add(new EndpointRegistration(method,
                                                       path,
                                                       category,
                                                       invocation,
                                                       description,
                                                       tag,
                                                       typeof(TAction)));
        }

        protected void Add(string method,
                           string path,
                           RouteCategory category,
                           Type actionType,
                           IEndpointInvocation invocation,
                           string? description,
                           string? tag)
        {
            Registrations.Add(new EndpointRegistration(method,
                                                       path,
                                                       category,
                                                       invocation,
                                                       description,
                                                       tag,
                                                       actionType));
        }

        public class EndpointRegistration
        {
            public EndpointRegistration(string method,
                                        string path,
                                        RouteCategory category,
                                        IEndpointInvocation invocation,
                                        string? description,
                                        string? tag,
                                        Type actionType)
            {
                Method = method;
                Path = path;
                Category = category;
                Invocation = invocation;
                Description = description;
                Tag = tag;
                ActionType = actionType;
            }

            public string Method { get; }
            public string Path { get; }
            public RouteCategory Category { get; }
            public IEndpointInvocation Invocation { get; }
            public Type ActionType { get; }
            public string? Description { get; }
            public string? Tag { get; }
        }
    }
}