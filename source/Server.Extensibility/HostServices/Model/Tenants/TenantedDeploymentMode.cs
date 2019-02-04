namespace Octopus.Server.Extensibility.HostServices.Model.Tenants
{
    public enum TenantedDeploymentMode
    {
        /// <summary>
        /// Eligible to be included only in untenanted deployments
        /// </summary>
        Untenanted,

        /// <summary>
        /// Eligible to be included in tenanted or untenanted deployments 
        /// </summary>
        TenantedOrUntenanted,

        /// <summary>
        /// Eligible to be included only in tenanted deployments 
        /// </summary>
        Tenanted
    }
}