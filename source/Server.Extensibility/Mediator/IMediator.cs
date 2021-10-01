using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Octopus.Server.MessageContracts;

namespace Octopus.Server.Extensibility.Mediator
{
    public interface IMediator
    {
        Task<TResponse> Do<TCommand, TResponse>(ICommand<TCommand, TResponse> command, CancellationToken cancellationToken)
            where TCommand : ICommand<TCommand, TResponse>
            where TResponse : IResponse;

        Task<TResponse> Request<TRequest, TResponse>(IRequest<TRequest, TResponse> request, CancellationToken cancellationToken)
            where TRequest : IRequest<TRequest, TResponse>
            where TResponse : IResponse;

        IAsyncEnumerable<TResponse> BroadcastRequest<TRequest, TResponse>(IBroadcastRequest<TRequest, TResponse> request, CancellationToken cancellationToken)
            where TRequest : IBroadcastRequest<TRequest, TResponse>
            where TResponse : IResponse;

        Task Publish<TEvent>(TEvent @event, CancellationToken cancellationToken)
            where TEvent : IEvent;
    }
}