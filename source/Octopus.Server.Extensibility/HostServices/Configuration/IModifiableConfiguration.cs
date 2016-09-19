using System;

namespace Octopus.Server.Extensibility.HostServices.Configuration
{
    public interface IModifiableConfiguration
    {
        void Save();
    }
}