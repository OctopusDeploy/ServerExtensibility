namespace Octopus.Server.Extensibility.HostServices.Authorization
{
    public interface IAuthorizationChecker
    {
        bool IsCurrentUserAdministrator();
    }
}