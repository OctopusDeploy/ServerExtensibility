using System.Linq;
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
            var urlSiteBase = request.Url.SiteBase;

            var forwardedHost = request.Headers["X-Forwarded-Host"].FirstOrDefault();
            if (forwardedHost != null)
            {
                var forwardedProto = request.Headers["X-Forwarded-Proto"].FirstOrDefault();

                urlSiteBase = $"{forwardedProto}://{forwardedHost}";
            }

            return urlSiteBase + request.Url.BasePath;
        }
    }
}