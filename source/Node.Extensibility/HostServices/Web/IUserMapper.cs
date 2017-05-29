using Octopus.Data.Model.User;

namespace Octopus.Node.Extensibility.HostServices.Web
{
    public interface IUserMapper
    {
        object MapToResource(IUser user);
    }
}