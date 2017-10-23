using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Nevermore.Contracts;
using Octopus.Node.Extensibility.Metadata;

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

        [ReadOnly(true)]
        public string Name { get; set; }

        [DisplayLabel("Author")]
        [Description("The author of this extension")]
        [ReadOnly(true)]
        public string ExtensionAuthor { get; set; }

        [DisplayLabel("Configuration Schema Version")]
        [Description("The schema version of this configuration document")]
        [ReadOnly(true)]
        public string ConfigurationSchemaVersion { get; set; }

        [DisplayLabel("Is Enabled")]
        [Description("Whether or not this extension is enabled")]
        [Required]
        public bool IsEnabled { get; set; }
    }
}