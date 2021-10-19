using System;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.HostServices.Configuration
{
    public interface IServerConfigurationStore
    {
        string? GetServerUri();
        Task<string?> GetServerUriAsync();
    }
}