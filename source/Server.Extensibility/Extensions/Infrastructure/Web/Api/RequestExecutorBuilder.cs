using System;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web.Api
{
    public class RequestExecutorBuilder<TParameterType>
    {
        readonly IOctoRequest request;
        readonly IResponderParameter<TParameterType> parameter;

        public RequestExecutorBuilder(IOctoRequest request, IResponderParameter<TParameterType> parameter)
        {
            this.request = request;
            this.parameter = parameter;
        }

        public WrappingRequestExecutorBuilder<TNextParameterType, TParameterType> WithParameter<TNextParameterType>(IResponderParameter<TNextParameterType> parameter)
        {
            return new WrappingRequestExecutorBuilder<TNextParameterType, TParameterType>(request, parameter, HandleAsync);
        }

        public Task<IOctoResponseProvider> HandleAsync(Func<TParameterType, Task<IOctoResponseProvider>> executor)
        {
            return request.GetParameterValue(parameter, executor);
        }
    }
    
    public class WrappingRequestExecutorBuilder<TParameterType, TWrappingParameterType>
    {
        readonly IOctoRequest request;
        readonly IResponderParameter<TParameterType> parameter;
        readonly Func<Func<TWrappingParameterType, Task<IOctoResponseProvider>>, Task<IOctoResponseProvider>> handler;

        public WrappingRequestExecutorBuilder(IOctoRequest request, IResponderParameter<TParameterType> parameter, Func<Func<TWrappingParameterType, Task<IOctoResponseProvider>>, Task<IOctoResponseProvider>> handler)
        {
            this.request = request;
            this.parameter = parameter;
            this.handler = handler;
        }

        public WrappingRequestExecutorBuilder<TNextParameterType, TParameterType> WithParameter<TNextParameterType>(IResponderParameter<TNextParameterType> nextParameter)
        {
            return new WrappingRequestExecutorBuilder<TNextParameterType, TParameterType>(request, nextParameter, func => HandleAsync(x => func));
        }

        public Task<IOctoResponseProvider> HandleAsync(Func<TWrappingParameterType, Func<TParameterType, Task<IOctoResponseProvider>>> executor)
        {
            return handler(t => request.GetParameterValue(parameter, p => executor(t)(p)));
        }
    }
}