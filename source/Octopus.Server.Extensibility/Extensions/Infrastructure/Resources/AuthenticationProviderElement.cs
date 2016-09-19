using System;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Resources
{
    public class AuthenticationProviderElement
    {
        public string Name { get; set; }

        public bool IsGuestProvider { get; set; }

        public bool FormsLoginEnabled { get; set; }

        public string FormsUsernameIdentifier { get; set; }

        public string FormsAuthenticateUri { get; set; }

        public string AuthenticateUri { get; set; }

        public string LinkHtml { get; set; }
    }
}