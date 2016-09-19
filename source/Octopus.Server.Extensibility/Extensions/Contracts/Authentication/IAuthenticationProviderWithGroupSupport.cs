using System;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Resources;

namespace Octopus.Server.Extensibility.Extensions.Contracts.Authentication
{
    public interface IAuthenticationProviderWithGroupSupport : IAuthenticationProvider
    {
        AuthenticationProviderThatSupportsGroups GetGroupLookupElement();
    }
}