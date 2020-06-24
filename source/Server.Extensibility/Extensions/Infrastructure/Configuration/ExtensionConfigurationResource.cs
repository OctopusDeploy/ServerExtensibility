using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Octopus.Data.Model;
using Octopus.Data.Resources;
using Octopus.Data.Resources.Attributes;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationResource : IResource
    {
        [DisplayName("Is Enabled")]
        [Description("Whether or not this extension is enabled")]
        [Required]
        [Writeable]
        public bool IsEnabled { get; set; }

        public string Id { get; set; }

        public LinkCollection Links { get; set; }
    }
}