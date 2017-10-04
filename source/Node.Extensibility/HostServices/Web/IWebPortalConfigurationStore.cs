namespace Octopus.Node.Extensibility.HostServices.Web
{
    public interface IWebPortalConfigurationStore
    {
        string[] GetListenPrefixes();

        bool GetForceSSL();

        string GetPublicBaseUrl();
    }
}