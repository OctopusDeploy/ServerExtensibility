using System;
using System.Diagnostics.CodeAnalysis;
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
        [return: NotNullIfNotNull("value")]
        public static DeploymentEnvironmentId? ToDeploymentEnvironmentId(this string? value)
        {
            return value == null ? null : new DeploymentEnvironmentId(value);
        }
    }}