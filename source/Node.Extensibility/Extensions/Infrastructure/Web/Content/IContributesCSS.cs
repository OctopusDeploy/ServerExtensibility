using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Web.Content
{
    public interface IContributesCSS
    {
        IEnumerable<string> GetCSSUris();
    }
}