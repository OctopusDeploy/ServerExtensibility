using System;
using Octopus.TinyTypes;

namespace Octopus.Server.Extensibility.HostServices.Model.Environments
{
    public class DeploymentEnvironmentId : CaseInsensitiveStringTinyType
    {
        public DeploymentEnvironmentId(string value) : base(value)
        {
        }
    }

    public static class DeploymentEnvironmentIdExtensionMethods
    {
        public static DeploymentEnvironmentId ToDeploymentEnvironmentId(this string value)
        {
            return new DeploymentEnvironmentId(value);
        }
    }}