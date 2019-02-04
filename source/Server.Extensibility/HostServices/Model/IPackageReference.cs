using System.Collections.Generic;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    public interface IPackageReference
    {
        string Id { get; }

        /// <summary>
        /// An name for the package-reference.
        /// This may be empty.
        /// This is used to discriminate the package-references. Package ID isn't suitable because an action may potentially
        /// have multiple references to the same package ID (e.g. if you wanted to use different versions of the same package).
        /// Also, the package ID may be a variable-expression. 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Package ID or a variable-expression 
        /// </summary>
        string PackageId { get; }

        /// <summary>
        /// Feed ID or a variable-expression
        /// </summary>
        string FeedId { get; }

        /// <summary>
        /// The package-acquisition location.
        /// One of <see cref="PackageAcquisitionLocation"/> or a variable-expression 
        /// </summary>
        string AcquisitionLocation { get; }

        bool IsPrimaryPackage { get; }

        IDictionary<string, string> Properties { get; }
    }
}