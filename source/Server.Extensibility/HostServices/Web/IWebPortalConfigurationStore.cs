using System;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public enum WebServer
    {
        HTTPsys,
        Kestrel
    }

    public interface IWebPortalConfigurationStore
    {
        /// <summary>
        ///     Returns the web portal configuration for the current Node.
        /// </summary>
        NodeWebPortalConfiguration GetCurrentNodeWebPortalConfiguration();

        string GetCorsWhitelist();

        WebServer GetWebServer();
    }
}