using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public class DeploymentEnvironmentName : CaseInsensitiveStringTinyType
    {
        public DeploymentEnvironmentName(string value) : base(value)
        {
        }
    }
}