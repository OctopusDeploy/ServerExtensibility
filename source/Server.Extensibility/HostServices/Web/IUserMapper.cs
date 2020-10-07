using System;
using Octopus.Data.Model.User;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public interface IUserMapper
    {
        object MapToResource(IUser user);
    }
}