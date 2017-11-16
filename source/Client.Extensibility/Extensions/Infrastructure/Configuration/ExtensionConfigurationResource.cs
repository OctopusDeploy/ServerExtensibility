using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Octopus.Client.Extensibility;

namespace Octopus.Client.Extensibility.Extensions.Infrastructure.Configuration
{
    public abstract class ExtensionConfigurationResource: IResource
    {
        public string Id { get; set; }

        [DisplayName("Is Enabled")]
        [Description("Whether or not this extension is enabled")]
        [Required]
        [ReadOnly(false)]
        public bool IsEnabled { get; set; }

        public LinkCollection Links { get; set; }
    }
}