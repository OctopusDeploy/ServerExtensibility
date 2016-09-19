using System;
using Nancy;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IApiAction
    {
        Response Execute(NancyContext context, IResponseFormatter response);
    }
}