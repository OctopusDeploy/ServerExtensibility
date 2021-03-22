using System;
using System.Threading;
using System.Threading.Tasks;
using Octopus.Server.MessageContracts;

namespace Octopus.Server.Extensibility.Mediator
{
    public interface IHandleCommand<in TCommand, TResponse>
        where TCommand : ICommand<TCommand, TResponse>
        where TResponse : IResponse
    {
        Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
    }
}