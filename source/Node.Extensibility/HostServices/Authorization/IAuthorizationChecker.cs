namespace Octopus.Node.Extensibility.HostServices.Authorization
{
    public interface IAuthorizationChecker
    {
        bool IsCurrentUserAdministrator();
    }
}