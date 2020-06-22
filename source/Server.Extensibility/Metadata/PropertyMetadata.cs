namespace Octopus.Server.Extensibility.Metadata
{
    public class PropertyMetadata
    {
        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public DisplayInfo DisplayInfo { get; set; } = new DisplayInfo();
    }
}