using System.Collections.Generic;

namespace Octopus.Node.Extensibility.HostServices.Web
{
    public interface IWebPortalConfigurationStore
    {
        /// <summary>
        /// Returns the web portal configuration for the current Node.
        /// </summary>
        NodeWebPortalConfiguration GetCurrentNodeWebPortalConfiguration();
    }
}