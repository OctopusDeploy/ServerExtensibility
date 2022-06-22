using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Octopus.Server.MessageContracts;
using Octopus.Server.MessageContracts.Attributes;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationResource : IResource
    {
        public string Id { get; set; } = string.Empty;

        [DisplayName("Is Enabled")]
        [Description("Whether or not this extension is enabled")]
        [Required]
        [Writeable]
        public bool IsEnabled { get; set; }

        public LinkCollection Links { get; set; } = new();
    }
}