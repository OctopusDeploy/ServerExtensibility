using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Octopus.Data.Model;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public class ActionTemplateParameter : INamed
    {
        public ActionTemplateParameter()
        {
            DisplaySettings = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        }

        [JsonConstructor]
        public ActionTemplateParameter(string name) : this()
        {
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string HelpText { get; set; }
        public PropertyValue DefaultValue { get; set; }
        public IDictionary<string, string> DisplaySettings { get; set; }

        [JsonIgnore]
        public bool HasDefault => DefaultValue != null && DefaultValue.HasValue;

        [JsonIgnore]
        public string VariableName => string.IsNullOrEmpty(Name) ? Label : Name;

        public ActionTemplateParameter Duplicate()
        {
            return new ActionTemplateParameter(Name)
            {
                Id = Id,
                Label = Label,
                HelpText = HelpText,
                DefaultValue = DefaultValue,
                DisplaySettings = new Dictionary<string, string>(DisplaySettings, StringComparer.OrdinalIgnoreCase)
            };
        }
    }
}