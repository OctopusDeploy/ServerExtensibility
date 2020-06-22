namespace Octopus.Server.Extensibility.Metadata
{
    public class DisplayInfo
    {
        public bool Required { get; set; }

        public bool ReadOnly { get; set; }

        public string Label { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public OptionsMetadata? Options { get; set; }

        public ListApiMetadata? ListApi { get; set; }
        
        public bool ShowCopyToClipboard { get; set; }
        
        public PropertyApplicability? PropertyApplicability { get; set; }
        
        public ConnectivityCheck? ConnectivityCheck { get; set; }
    }
}