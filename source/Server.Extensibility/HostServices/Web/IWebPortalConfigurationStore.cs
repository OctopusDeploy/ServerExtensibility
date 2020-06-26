namespace Octopus.Server.Extensibility.HostServices.Web
{
    public interface IWebPortalConfigurationStore
    {
        /// <summary>
        ///     Returns the web portal configuration for the current Node.
        /// </summary>
        NodeWebPortalConfiguration GetCurrentNodeWebPortalConfiguration();
    }
}