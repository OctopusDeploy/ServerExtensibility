namespace Octopus.Node.Extensibility.HostServices.Web
{
    public interface IAuthenticationConfigurationStore
    {
        string[] GetTrustedRedirectUrls();

        bool GetIsAutoLoginEnabled();
    }
}