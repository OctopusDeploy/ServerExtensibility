using Octopus.Server.Extensibility.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public class DeploymentEnvironmentId : CaseInsensitiveStringTinyType
    {
        public DeploymentEnvironmentId(string value) : base(value)
        {
        }
    }
}