using Octopus.Server.Extensibility.HostServices.Domain.Events;
using Octopus.Server.Extensibility.HostServices.Model.PackageMetadata;

namespace Octopus.Server.Extensibility.Domain.PackageMetadata
{
    public enum PackageMetadataEventType
    {
        PackageMetadataCreated,
        PackageMetadataModified,
        PackageMetadataDeleted
    }

    public class PackageMetadataEvent : DomainEvent
    {
        public PackageMetadataEvent(PackageMetadataEventType eventType, IPackageVersionMetadata packageVersionMetadata)
        {
            EventType = eventType;
            PackageVersionMetadata = packageVersionMetadata;
        }

        public PackageMetadataEventType EventType { get; }
        public IPackageVersionMetadata PackageVersionMetadata { get; }
    }
}