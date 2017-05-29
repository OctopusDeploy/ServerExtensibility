namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHandleLegacyWebAuthenticationModeConfigurationCommand
    {
        void Handle(string webAuthenticationMode);
    }
}