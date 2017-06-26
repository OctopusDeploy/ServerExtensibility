using Nancy.Helpers;
using Octopus.Node.Extensibility.HostServices.Web;

namespace Octopus.Server.Extensibility.HostServices.Web
{
    public class UrlEncoder : IUrlEncoder
    {
        public string UrlEncode(string value)
        {
            return HttpUtility.UrlEncode(value);
        }

        public string UrlDecode(string value)
        {
            return HttpUtility.UrlDecode(value);
        }
    }
}