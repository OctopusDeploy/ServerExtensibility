using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public class DeploymentEnvironmentIdOrName : CaseInsensitiveStringTinyType, IIdOrNameTinyType
    {
        public DeploymentEnvironmentIdOrName(string value) : base(value)
        {
        }
    }
}