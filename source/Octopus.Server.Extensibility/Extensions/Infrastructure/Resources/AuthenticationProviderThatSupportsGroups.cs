using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Resources
{
    public class AuthenticationProviderThatSupportsGroups
    {
        public string Id => Name;

        public string Name { get; set; }

        public bool IsRoleBased { get; set; }

        public bool SupportsGroupLookup { get; set; }
        public string LookupUri { get; set; }
    }
}