using System;

namespace Octopus.Server.Extensibility.HostServices.Time
{
    public interface IClock
    {
        DateTimeOffset GetUtcTime();
        DateTimeOffset GetLocalTime();
    }
}