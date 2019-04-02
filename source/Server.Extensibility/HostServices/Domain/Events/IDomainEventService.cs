using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.HostServices.Domain.Events
{
    public interface IDomainEventService
    {
        void RaiseEvent<TEvent>(TEvent @event)
            where TEvent : DomainEvent;

        Task RaiseEventAsync<TEvent>(TEvent @event)
            where TEvent : DomainEvent;
    }
}