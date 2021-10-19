using System;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.HostServices.Licensing
{
    public interface IInstallationIdProvider
    {
        Guid GetInstallationId();

        Task<Guid> GetInstallationIdAsync();
    }
}