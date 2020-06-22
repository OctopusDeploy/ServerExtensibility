namespace Octopus.Server.Extensibility.Resources
{
    public class DeploymentActionPackageResource
    {
        /// <summary>
        /// The name or ID of the deployment action
        /// </summary>
        public string DeploymentAction { get; set; } = string.Empty;

        /// <summary>
        /// The name of ID of the package reference
        /// </summary>
        public string PackageReference { get; set; } = string.Empty;
    }
}