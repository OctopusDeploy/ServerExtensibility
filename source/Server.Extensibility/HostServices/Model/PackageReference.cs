using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Octopus.Data.Model;
using Octopus.Ocl.Converters;
using Octopus.Server.Extensibility.Resources;
using Octopus.Server.MessageContracts.Features.Feeds;
using IId = Octopus.Data.Model.IId;

namespace Octopus.Server.Extensibility.HostServices.Model
{
    /// <summary>
    ///     Represents a reference from a deployment-process (specifically an action or action-template) to a package.
    ///     May be named or un-named.
    /// </summary>
    /// <history>
    ///     Prior to Octopus 2018.8, deployment actions could have at most a single package-reference. This was
    ///     captured as properties on the action (Octopus.Action.Package.PackageId, Octopus.Action.Package.FeedId, etc).
    ///     In 2018.8, we introduced support for actions with multiple packages (initially script steps and kubernetes step).
    ///     Storing collections of nested objects in the property-bag gets very messy, so package-references were moved into
    ///     their own class
    ///     and collection on the deployment actions.
    /// </history>
    public class PackageReference : IId, INamed
    {
        /// <summary>
        ///     Constructs a named package-reference.
        /// </summary>
        /// <param name="name">The package-reference name.</param>
        /// <param name="packageId">The package ID or a variable-expression</param>
        /// <param name="feedId">The feed ID or a variable-expression</param>
        /// <param name="acquisitionLocation">The location the package should be acquired</param>
        public PackageReference(string? name, string packageId, FeedId feedId, PackageAcquisitionLocation acquisitionLocation)
            : this(name, packageId, feedId, acquisitionLocation.ToString())
        {
        }

        /// <summary>
        ///     Constructs a named package-reference.
        /// </summary>
        /// <param name="name">The package-reference name.</param>
        /// <param name="packageId">The package ID or a variable-expression</param>
        /// <param name="feedId">The feed ID or a variable-expression</param>
        /// <param name="acquisitionLocation">The location the package should be acquired.
        /// May be one <see cref="PackageAcquisitionLocation" /> or a variable-expression.</param>
        public PackageReference(string? name, string packageId, FeedId feedId, string acquisitionLocation)
            : this(null,
                   name,
                   packageId,
                   feedId,
                   acquisitionLocation)
        {
        }

        /// <summary>
        ///     For JSON deserialization only
        /// </summary>
        [JsonConstructor]
        public PackageReference(string? id,
                                string? name,
                                string packageId,
                                FeedId feedId,
                                string acquisitionLocation)
            : this()
        {
            if (!string.IsNullOrEmpty(id)) Id = id;

            PackageId = packageId;
            FeedId = feedId;
            AcquisitionLocation = acquisitionLocation;
            Name = name ?? string.Empty;
        }

        /// <summary>
        ///     Constructs a primary package (an un-named package reference)
        /// </summary>
        public PackageReference(string packageId, FeedId feedId, PackageAcquisitionLocation acquisitionLocation)
            : this(null, packageId, feedId, acquisitionLocation)
        {
        }

        /// <summary>
        ///     Constructs a primary package (an un-named package reference)
        /// </summary>
        public PackageReference(string packageId, FeedId feedId, string acquisitionLocation)
            : this(null, packageId, feedId, acquisitionLocation)
        {
        }

        /// <summary>
        ///     Constructs a primary package (an un-named package reference)
        /// </summary>
        public PackageReference(string packageId, FeedId feedId)
            : this(packageId, feedId, PackageAcquisitionLocation.Server)
        {
        }

        /// <summary>
        ///     In the scenario where we are migrating from 2.6 instances, we set the ID of the package-reference
        ///     to the same ID as the deployment-action.
        ///     This was the least-bad option that let the migrator do its thing when migrating project
        ///     release-creation-strategy and versioning-strategy.
        /// </summary>
        public PackageReference(string id) : this()
        {
            if (!string.IsNullOrEmpty(id)) Id = id;
        }

        public PackageReference()
        {
            Id = Guid.NewGuid().ToString();
            Properties = new Dictionary<string, string>();
            FeedId = "feeds-builtin".ToFeedId();
        }

        public string Id { get; }

        /// <summary>
        ///     An name for the package-reference.
        ///     This may be empty.
        ///     This is used to discriminate the package-references. Package ID isn't suitable because an action may potentially
        ///     have multiple references to the same package ID (e.g. if you wanted to use different versions of the same package).
        ///     Also, the package ID may be a variable-expression.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///     Package ID or a variable-expression
        /// </summary>
        public string PackageId { get; set; } = string.Empty;

        /// <summary>
        ///     Feed ID, name or a variable-expression
        /// </summary>
        [OclName("feed")]
        public FeedId FeedId { get; set; }

        /// <summary>
        ///     The package-acquisition location.
        ///     One of <see cref="PackageAcquisitionLocation" /> or a variable-expression
        /// </summary>
        public string AcquisitionLocation { get; set; } = string.Empty;

        /// <summary>
        ///     This reference identifier is populated when a step package step contains a package reference
        ///     It allows us to correlate the reference within the step package inputs to this Server package reference
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? StepPackageInputsReferenceId { get; set; }

        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public IDictionary<string, string> Properties { get; private set; }

        [JsonIgnore]
        public bool IsPrimaryPackage => Name == "";

        public PackageReference Clone()
        {
            return new PackageReference(Id,
                                        Name,
                                        PackageId,
                                        FeedId,
                                        AcquisitionLocation)
            {
                Properties = new Dictionary<string, string>(Properties),
                StepPackageInputsReferenceId = StepPackageInputsReferenceId
            };
        }

        /// <summary>
        ///     Performs a case-insensitive comparison between the name of this package-reference and the
        ///     supplied name.  Nulls and empty strings are considered equal.
        /// </summary>
        public bool NameMatches(string name)
        {
            return Name == ""
                ? string.IsNullOrEmpty(name)
                : Name.Equals(name, StringComparison.OrdinalIgnoreCase);
        }
    }
}