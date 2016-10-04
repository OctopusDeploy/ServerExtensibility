using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public class ConfigureCommandOption
    {
        public ConfigureCommandOption(string prototype, string description, Action<string> action)
        {
            Prototype = prototype;
            Description = description;
            Action = action;
        }

        public string Prototype { get; set; }
        public string Description { get; set; }

        public Action<string> Action { get; set; }
    }
}