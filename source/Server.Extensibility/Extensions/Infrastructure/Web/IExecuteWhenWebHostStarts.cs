namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web
{
    public interface IExecuteWhenWebHostStarts
    {
        /// <summary>
        /// Will be called when the web host is about to start
        /// </summary>
        void OnWebHostStarting();

        /// <summary>
        /// Will be called when the web host has started
        /// </summary>
        void OnWebHostStarted();

        /// <summary>
        /// Will be called when the web host is stopping
        /// </summary>
        void OnWebHostStopping();
    }
}