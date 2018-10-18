using System.Collections.Generic;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Content
{
    public interface IContributesStaticContentFolders
    {
        IEnumerable<StaticContentEmbeddedResourcesFolder> GetStaticContentFolders();
    }
}