using System.Threading;
using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Storage
{
    public interface IDynamicExtensionsStorage
    {
        public Task<T> Get<T>(string extensionId, string key, CancellationToken token);
        public Task Set<T>(string extensionId, string key, T value, CancellationToken token);
        Task Delete(string extensionId, string key, CancellationToken token);
    }
}