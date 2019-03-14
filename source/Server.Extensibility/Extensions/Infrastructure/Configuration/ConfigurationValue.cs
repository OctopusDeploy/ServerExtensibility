using Newtonsoft.Json;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{

    public class ConfigurationValue<T> : IConfigurationValue
    {
        protected ConfigurationValue()
        {}

        public ConfigurationValue(string key, T value, bool showInPortalSummary, string description = "", bool isSensitive = false)
        {
            Key = key;
            TypedValue = value;
            ShowInPortalSummary = showInPortalSummary;
            Description = description;
            IsSensitive = isSensitive;
        }

        public string Key { get; set; }
        public object Value => TypedValue;
        [JsonIgnore]
        public T TypedValue { get; set; }
        public bool ShowInPortalSummary { get; set; }
        public string Description { get; set; }
        public bool IsSensitive { get; set; }
    }

    public interface IConfigurationValue
    {
        string Key { get; set; }
        object Value { get; }
        bool ShowInPortalSummary { get; set; }
        string Description { get; set; }
        bool IsSensitive { get; set; }
    }
}