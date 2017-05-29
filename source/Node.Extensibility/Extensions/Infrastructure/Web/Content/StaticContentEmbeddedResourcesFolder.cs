using System.Reflection;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Web.Content
{
    public class StaticContentEmbeddedResourcesFolder
    {
        public StaticContentEmbeddedResourcesFolder(string virtualDirectory, Assembly assembly, string @namespace)
        {
            VirtualDirectory = virtualDirectory;
            Assembly = assembly;
            Namespace = @namespace;
        }

        public string VirtualDirectory { get; set; }
        public Assembly Assembly { get; private set; }
        public string Namespace { get; private set; }
    }
}