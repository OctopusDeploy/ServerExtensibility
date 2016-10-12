using Octopus.Server.Extensibility.HostServices.Model;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationDocument : IDocument
    {
        protected ExtensionConfigurationDocument()
        {
        }

        protected ExtensionConfigurationDocument(string name, string extensionAuthor, string extensionVersion)
        {
            Name = name;
            ExtensionAuthor = extensionAuthor;
            ExtensionVersion = extensionVersion;
        }

        public string Id { get; protected set; }

        public string Name { get; set; }

        public string ExtensionAuthor { get; set; }

        public string ExtensionVersion { get; set; }
    }
}