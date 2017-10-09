using Nevermore.Contracts;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
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

        public string Id { get; set; }

        public string Name { get; set; }

        public string ExtensionAuthor { get; set; }
    }
}