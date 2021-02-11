using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public class DeploymentEnvironmentId : CaseInsensitiveStringTinyType, IIdTinyType
    {
        public DeploymentEnvironmentId(string value) : base(value)
        {
        }
    }
}