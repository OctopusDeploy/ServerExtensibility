namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public class ConfigurationValue
    {
        protected ConfigurationValue()
        {}

        public ConfigurationValue(string key, string value, bool showInPortalSummary, string description = "", bool isSensitive = false)
        {
            Key = key;
            Value = value;
            ShowInPortalSummary = showInPortalSummary;
            Description = description;
            IsSensitive = isSensitive;
        }

        public string Key { get; set; }
        public string Value { get; set; }
        public bool ShowInPortalSummary { get; set; }

        public string Description { get; set; }
        public bool IsSensitive { get; set; }
    }
}