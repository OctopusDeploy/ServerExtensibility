using System;
using Octopus.Server.Extensibility.HostServices.Domain.Events;
using Octopus.Server.Extensibility.HostServices.Model.Projects;

namespace Octopus.Server.Extensibility.Domain.Releases
{
    public enum ReleaseEventType
    {
        Created,
        Deleted
    }

    public class ReleaseEvent : DomainEvent
    {
        public ReleaseEvent(ReleaseEventType eventType, IRelease release)
        {
            EventType = eventType;
            Release = release;
        }

        public ReleaseEventType EventType { get; }
        public IRelease Release { get; }
    }
}