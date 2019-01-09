using Octopus.Server.Extensibility.HostServices.Domain.Events;

namespace Octopus.Server.Extensibility.Extensions.Domain
{
    public interface IObserveDomainEvents
    {
    }

    public interface IObserveDomainEvent<in TEvent> : IObserveDomainEvents
        where TEvent: DomainEvent
    {
        void Handle(TEvent @event);
    }
}