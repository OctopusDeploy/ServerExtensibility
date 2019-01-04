using System;

namespace Octopus.Server.Extensibility.HostServices.Licensing
{
    public interface IInstallationIdProvider
    {
        Guid GetInstallationId();
    }
}