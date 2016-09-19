using System;
using Octopus.Server.Extensibility.HostServices.Model;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public interface IUserMapper
    {
        object MapToResource(IUser user);
    }
}