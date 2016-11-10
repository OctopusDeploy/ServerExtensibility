using System;
using System.Linq;
using Nancy;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public static class NancyRequestExtensions
    {
        /// <summary>
        /// Builds the path to the virtual directory for the given Request.  This is required in scenarios where the server 
        /// needs to understand the absolute path it was called on, from the browser's perspecive.  This is essential to
        /// making things like the OpenID Connect login process work, because we have to provide them a redirectUrl that will
        /// get them back to our API using the same protocol and host that the original call was made on (remembering that there
        /// could be multiple listening prefixes at play and we could also be behind a reverse proxy).
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>A result representing full virtual directory path, if it could be determined; otherwise a result explaining 
        /// why it couldn't be determined.</returns>
        public static DirectoryPathResult DirectoryPath(this Request request)
        {
            var urlSiteBase = request.Url.SiteBase;

            var forwardedHost = request.Headers["X-Forwarded-Host"].FirstOrDefault();
            if (forwardedHost != null)
            {
                var forwardedProto = request.Headers["X-Forwarded-Proto"].FirstOrDefault();

                if (forwardedProto == null)
                    return DirectoryPathResult.Invalid("X-Forwarded-Host' was supplied, but 'X-Forwarded-Proto' header was not. Please configure your proxy to pass this header through.");

                urlSiteBase = $"{forwardedProto}://{forwardedHost}";
            }

            return DirectoryPathResult.Success(urlSiteBase + request.Url.BasePath);
        }
    }
}