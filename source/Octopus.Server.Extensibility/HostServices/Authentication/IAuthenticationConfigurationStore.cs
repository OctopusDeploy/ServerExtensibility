
using System;

namespace Octopus.Server.Extensibility.HostServices.Authentication
{
    public interface IAuthenticationConfigurationStore
    {
        AuthenticationMode GetAuthenticationMode();
    }
}