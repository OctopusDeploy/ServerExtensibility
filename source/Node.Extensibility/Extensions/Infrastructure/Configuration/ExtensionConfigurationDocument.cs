using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Nevermore.Contracts;
using Octopus.Data.Resources.Attributes;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationDocument : IDocument
    {
        protected ExtensionConfigurationDocument()
        {
        }

        protected ExtensionConfigurationDocument(string name, string extensionAuthor, string configurationSchemaVersion)
        {
            Name = name;
            ExtensionAuthor = extensionAuthor;
            ConfigurationSchemaVersion = configurationSchemaVersion;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Author")]
        [Description("The author of this extension")]
        public string ExtensionAuthor { get; set; }

        [DisplayName("Configuration Schema Version")]
        [Description("The schema version of this configuration document")]
        public string ConfigurationSchemaVersion { get; set; }

        [DisplayName("Is Enabled")]
        [Description("Whether or not this extension is enabled")]
        [Required]
        [Writeable]
        public bool IsEnabled { get; set; }
    }
}