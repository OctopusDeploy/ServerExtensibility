using Nancy;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public static class NancyRequestExtensions
    {
        /// <summary>
        /// Builds the path to the virtual directory for the given Request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The full virtual directory path.</returns>
        public static string DirectoryPath(this Request request)
        {
            return request.Url.SiteBase + request.Url.BasePath;
        }
    }
}