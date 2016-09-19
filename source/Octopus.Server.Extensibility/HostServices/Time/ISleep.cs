using System;

namespace Octopus.Server.Extensibility.HostServices.Time
{
    public interface ISleep
    {
        void For(int milliseconds);
    }
}