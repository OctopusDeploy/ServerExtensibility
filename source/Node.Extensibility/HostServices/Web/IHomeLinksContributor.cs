using System.Collections.Generic;

namespace Octopus.Node.Extensibility.HostServices.Web
{
    public interface IHomeLinksContributor
    {
        IDictionary<string, string> GetLinksToContribute();
    }
}