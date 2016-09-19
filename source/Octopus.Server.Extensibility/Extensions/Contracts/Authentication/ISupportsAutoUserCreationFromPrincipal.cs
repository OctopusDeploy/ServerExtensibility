using System;
using System.Security.Principal;
using Octopus.Server.Extensibility.HostServices.Model;

namespace Octopus.Server.Extensibility.Extensions.Contracts.Authentication
{
    public interface ISupportsAutoUserCreationFromPrincipal
    {
        UserCreateOrUpdateResult GetOrCreateUser(IPrincipal principal);
    }
}