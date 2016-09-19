using System;
using System.Net;

namespace Octopus.Server.Extensibility.Extensions.Contracts.Authentication
{
    public interface IAuthenticationSchemeProvider
    {
        string ChallengePath { get; }
        AuthenticationSchemes AuthenticationScheme { get; }
    }
}