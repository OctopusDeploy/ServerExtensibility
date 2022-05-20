using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public interface ISpaceScopedHomeLinksContributor
    {
        IDictionary<string, string> GetLinksToContribute();
    }
}