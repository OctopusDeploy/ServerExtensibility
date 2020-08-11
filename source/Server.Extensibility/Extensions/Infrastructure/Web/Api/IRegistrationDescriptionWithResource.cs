using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public interface IRegistrationDescriptionWithResource
    {
        Type ResourceType { get; }
        string GetDescription(string friendlyTypeName);
    }
}