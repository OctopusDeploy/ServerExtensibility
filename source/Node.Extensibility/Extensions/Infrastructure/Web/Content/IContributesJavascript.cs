using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Web.Content
{
    public interface IContributesJavascript
    {
        IEnumerable<string> GetJavascriptUris();
    }
}