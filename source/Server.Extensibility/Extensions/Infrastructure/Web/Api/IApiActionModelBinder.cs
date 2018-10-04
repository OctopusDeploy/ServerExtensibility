using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IApiActionModelBinder
    {
        TModel Bind<TModel>();
        TModel BindAndValidate<TModel>();
    }
}