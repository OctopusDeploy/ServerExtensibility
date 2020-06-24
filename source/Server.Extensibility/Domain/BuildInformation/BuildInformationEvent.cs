using Octopus.Server.Extensibility.HostServices.Domain.Events;
using Octopus.Server.Extensibility.HostServices.Model.BuildInformation;

namespace Octopus.Server.Extensibility.Domain.BuildInformation
{
    public enum BuildInformationEventType
    {
        BuildInformationCreated,
        BuildInformationModified,
        BuildInformationDeleted
    }

    public class BuildInformationEvent : DomainEvent
    {
        public BuildInformationEvent(BuildInformationEventType eventType,
            IPackageVersionBuildInformation packageVersionBuildInformation)
        {
            EventType = eventType;
            PackageVersionBuildInformation = packageVersionBuildInformation;
        }

        public BuildInformationEventType EventType { get; }
        public IPackageVersionBuildInformation PackageVersionBuildInformation { get; }
    }
}