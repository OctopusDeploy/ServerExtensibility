namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IHandleLegacyWebAuthenticationModeConfigurationCommand
    {
        void Handle(string webAuthenticationMode);
    }
}