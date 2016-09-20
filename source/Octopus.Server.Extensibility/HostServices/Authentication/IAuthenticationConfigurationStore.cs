using System;

namespace Octopus.Server.Extensibility.HostServices.Authentication
{
    public interface IAuthenticationConfigurationStore
    {
        string GetAuthenticationMode();
    }
}