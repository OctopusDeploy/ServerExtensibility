using System;

namespace Octopus.Server.Extensibility.HostServices.Authentication
{
    public interface ILoginRecorder
    {
        void RecordFailure(string attemptedUsername, string ipAddress);
        void RecordSucess(string attemptedUsername, string ipAddress);
    }
}