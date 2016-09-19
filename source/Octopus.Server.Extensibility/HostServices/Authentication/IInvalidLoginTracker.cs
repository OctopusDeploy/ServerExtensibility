using System;

namespace Octopus.Server.Extensibility.HostServices.Authentication
{
    public interface IInvalidLoginTracker : ILoginRecorder
    {
        InvalidLoginAction BeforeAttempt(string attemptedUsername, string ipAddress);
    }
}