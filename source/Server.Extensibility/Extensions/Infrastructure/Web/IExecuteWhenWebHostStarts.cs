using System.Threading.Tasks;

namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web
{
    public interface IExecuteWhenWebHostStarts
    {
        /// <summary>
        /// Will be called when the web host is about to start
        /// </summary>
        Task OnWebHostStarting();

        /// <summary>
        /// Will be called when the web host has started
        /// </summary>
        Task OnWebHostStarted();

        /// <summary>
        /// Will be called when the web host is stopping
        /// </summary>
        Task OnWebHostStopping();
    }
}