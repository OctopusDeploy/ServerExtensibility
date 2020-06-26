using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web
{
    public interface IShareWebHostLifetime
    {
        /// <summary>
        ///     Will be called when the web host starts
        /// </summary>
        Task StartAsync();

        /// <summary>
        ///     Will be called when the web host is stopping
        /// </summary>
        Task StopAsync();
    }
}