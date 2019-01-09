namespace Octopus.Server.Extensibility.HostServices.Domain.Events
{
    public interface IDomainEventService
    {
        void RaiseEvent(DomainEvent @event);
    }
}