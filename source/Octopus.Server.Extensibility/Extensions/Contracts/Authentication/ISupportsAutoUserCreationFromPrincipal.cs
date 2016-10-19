using System;
using System.Security.Principal;
using Octopus.Data.Storage.User;

namespace Octopus.Server.Extensibility.Extensions.Contracts.Authentication
{
    public interface ISupportsAutoUserCreationFromPrincipal
    {
        UserCreateOrUpdateResult GetOrCreateUser(IPrincipal principal);
    }
}