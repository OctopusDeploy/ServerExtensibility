using System;
using System.Threading;
using System.Threading.Tasks;
using Octopus.Server.MessageContracts.Base;

namespace Octopus.Server.Extensibility.Mediator
{
    public interface IHandleRequest<in TRequest, TResponse>
        where TRequest : IRequest<TRequest, TResponse>
        where TResponse : IResponse
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
    }
}