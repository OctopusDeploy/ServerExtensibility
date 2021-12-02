using System;
using System.Collections.Generic;
using System.Threading;
using Octopus.Server.MessageContracts.Base;

namespace Octopus.Server.Extensibility.Mediator
{
    public interface IHandleBroadcastRequest<TRequest, TResponse>
        where TRequest : IBroadcastRequest<TRequest, TResponse>
        where TResponse : IResponse

    {
        IAsyncEnumerable<TResponse> Handle(IBroadcastRequest<TRequest, TResponse> request, CancellationToken cancellationToken);
    }
}