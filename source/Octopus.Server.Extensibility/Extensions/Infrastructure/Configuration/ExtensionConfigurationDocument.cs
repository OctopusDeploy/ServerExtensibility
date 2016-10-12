using Octopus.Server.Extensibility.HostServices.Model;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationDocument : IDocument
    {
        protected ExtensionConfigurationDocument()
        {
        }

        protected ExtensionConfigurationDocument(string name, string extensionAuthor)
        {
            Name = name;
            ExtensionAuthor = extensionAuthor;
        }

        public string Id { get; protected set; }

        public string Name { get; set; }

        public string ExtensionAuthor { get; set; }
    }
}