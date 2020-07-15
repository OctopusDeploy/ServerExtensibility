using System;

namespace Octopus.Server.Extensibility.HostServices.Configuration
{
    public interface IServerConfigurationStore
    {
        string? GetServerUri();
    }
}