namespace Octopus.Server.Extensibility.HostServices.Model
{
    /// <summary>
    /// Represents a reference from a deployment-action to a package.
    /// </summary>
    public interface IPackageReference
    {
        string PackageId { get; }
        string FeedId { get; }
    }
}