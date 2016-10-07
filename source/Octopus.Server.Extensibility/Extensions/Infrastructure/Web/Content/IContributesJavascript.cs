using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Content
{
    public interface IContributesJavascript
    {
        IEnumerable<string> GetJavascriptUris(string siteBaseUri);
    }
}