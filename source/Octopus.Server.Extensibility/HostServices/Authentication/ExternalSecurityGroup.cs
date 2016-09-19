using System;

namespace Octopus.Server.Extensibility.HostServices.Authentication
{
    public class ExternalSecurityGroup
    {
        /// <summary>
        /// The identifier for the group/role.  For roles this will usually be their name, for groups it'll be a sid.
        /// </summary>
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public bool DisplayIdAndName { get; set; }
    }
}