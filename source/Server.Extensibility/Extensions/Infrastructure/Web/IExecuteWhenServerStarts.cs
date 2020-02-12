namespace Octopus.Server.Extensibility.Extensions.Infrastructure.Web
{
    public interface IExecuteWhenServerStarts
    {
        /// <summary>
        /// Will be called when the web host is about to start
        /// </summary>
        void OnHostStarting();

        /// <summary>
        /// Will be called when the web host has started
        /// </summary>
        void OnHostStarted();
    }
}