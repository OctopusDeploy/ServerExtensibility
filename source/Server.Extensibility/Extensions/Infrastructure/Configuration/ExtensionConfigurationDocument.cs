using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Octopus.Data.Model.Configuration;
using Octopus.Data.Resources.Attributes;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationDocument : ConfigurationDocument
    {
        protected ExtensionConfigurationDocument(string id) : base(id)
        {
        }

        protected ExtensionConfigurationDocument(string id,
            string name,
            string extensionAuthor,
            string configurationSchemaVersion) : base(id)
        {
            Name = name;
            ExtensionAuthor = extensionAuthor;
            ConfigurationSchemaVersion = configurationSchemaVersion;
        }

        public string Name { get; set; } = string.Empty;

        [DisplayName("Author")]
        [Description("The author of this extension")]
        public string ExtensionAuthor { get; set; } = string.Empty;

        [DisplayName("Configuration Schema Version")]
        [Description("The schema version of this configuration document")]
        public string ConfigurationSchemaVersion { get; set; } = string.Empty;

        [DisplayName("Is Enabled")]
        [Description("Whether or not this extension is enabled")]
        [Required]
        [Writeable]
        public bool IsEnabled { get; set; }
    }
}