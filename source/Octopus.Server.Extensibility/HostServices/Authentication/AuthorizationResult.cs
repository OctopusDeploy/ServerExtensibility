using System;

namespace Octopus.Server.Extensibility.HostServices.Authentication
{
    public class AuthorizationResult
    {
        readonly Lazy<string> helpText;

        public AuthorizationResult(bool isAuthorized, Lazy<string> helpText = null)
        {
            IsAuthorized = isAuthorized;
            this.helpText = helpText ?? new Lazy<string>(() => null);
        }

        public bool IsAuthorized { get; }

        public string HelpText => helpText.Value;
    }
}