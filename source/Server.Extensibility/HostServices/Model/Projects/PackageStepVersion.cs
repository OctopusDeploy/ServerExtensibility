using Newtonsoft.Json;

namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    /// <summary>
    /// Represents a selected NuGet package version for a package step.
    /// </summary>
    public class PackageStepVersion : IPackageStepVersion
    {
        public PackageStepVersion(string actionName, string version)
            : this(actionName, null, version)
        { }

        [JsonConstructor]
        public PackageStepVersion(string actionName, string? packageReferenceName, string version)
        {
            ActionName = actionName;
            PackageReferenceName = packageReferenceName ?? string.Empty;
            Version = version;
        }

        public string ActionName { get; }

        /// <summary>
        /// Actions that can have multiple packages allow naming package references.
        /// This will be empty for package references which do not require a name.
        /// </summary>
        public string PackageReferenceName { get; }

        public string Version { get; }
    }
}