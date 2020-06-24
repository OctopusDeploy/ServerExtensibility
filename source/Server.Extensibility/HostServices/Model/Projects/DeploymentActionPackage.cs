using System;
using Newtonsoft.Json;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    /// <summary>
    ///     Represents a package referenced by a deployment action.
    /// </summary>
    public class DeploymentActionPackage
    {
        [JsonConstructor]
        public DeploymentActionPackage(string deploymentActionId, string packageReferenceId)
        {
            DeploymentActionId = deploymentActionId;
            PackageReferenceId = packageReferenceId;
        }

        public string DeploymentActionId { get; }

        public string PackageReferenceId { get; }

        public DeploymentActionPackage Clone()
        {
            return new DeploymentActionPackage(DeploymentActionId, PackageReferenceId);
        }

        public static DeploymentActionPackage ForPrimaryPackage(IDeploymentAction deploymentAction)
        {
            return new DeploymentActionPackage(deploymentAction.Id, deploymentAction.Packages.PrimaryPackage.Id);
        }

        #region Equality members

        protected bool Equals(DeploymentActionPackage other)
        {
            return
                string.Equals(DeploymentActionId, other.DeploymentActionId, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(PackageReferenceId, other.PackageReferenceId, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((DeploymentActionPackage) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((DeploymentActionId != null
                    ? StringComparer.OrdinalIgnoreCase.GetHashCode(DeploymentActionId)
                    : 0) * 397) ^ (PackageReferenceId != null
                    ? StringComparer.OrdinalIgnoreCase.GetHashCode(PackageReferenceId)
                    : 0);
            }
        }

        #endregion
    }
}