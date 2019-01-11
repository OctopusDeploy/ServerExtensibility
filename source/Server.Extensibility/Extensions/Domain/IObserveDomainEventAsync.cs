using System.Threading.Tasks;
using Octopus.Server.Extensibility.HostServices.Domain.Events;

namespace Octopus.Server.Extensibility.Extensions.Domain
{
    public interface IObserveDomainEventAsync<in TEvent> : IObserveDomainEvents
        where TEvent: DomainEvent
    {
        Task HandleAsync(TEvent @event);
    }
}