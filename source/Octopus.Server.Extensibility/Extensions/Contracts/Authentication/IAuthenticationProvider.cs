using System;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Resources;

namespace Octopus.Server.Extensibility.Extensions.Contracts.Authentication
{
    public interface IAuthenticationProvider
    {
        string IdentityProviderName { get; }

        bool IsEnabled { get; }

        bool SupportsPasswordManagement { get; }

        AuthenticationProviderElement GetAuthenticationProviderElement(string siteBaseUri);
    }
}