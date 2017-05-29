using System.Collections.Generic;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Web.Content
{
    public interface IContributesStaticContentFolders
    {
        IEnumerable<StaticContentEmbeddedResourcesFolder> GetStaticContentFolders();
    }
}