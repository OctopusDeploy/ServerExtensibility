using System;
using Nancy;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IApiActionModelBinder
    {
        TModel Bind<TModel>(NancyContext context);
        TModel BindAndValidate<TModel>(NancyContext context);
    }
}