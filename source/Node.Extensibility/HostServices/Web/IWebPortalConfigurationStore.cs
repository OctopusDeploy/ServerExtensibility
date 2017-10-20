using System.Collections.Generic;

namespace Octopus.Node.Extensibility.HostServices.Web
{
    public interface IWebPortalConfigurationStore
    {
        IDictionary<string, NodeWebPortalConfiguration> GetNodeWebPortalConfigurations();

        string GetPublicBaseUrl();
    }
}