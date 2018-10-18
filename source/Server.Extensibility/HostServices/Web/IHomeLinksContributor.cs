using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public interface IHomeLinksContributor
    {
        IDictionary<string, string> GetLinksToContribute();
    }
}