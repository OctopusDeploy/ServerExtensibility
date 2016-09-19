using System;

namespace Octopus.Server.Extensibility.HostServices.Authentication
{
    public enum InvalidLoginAction
    {
        Continue,
        Slow,
        Ban
    }
}