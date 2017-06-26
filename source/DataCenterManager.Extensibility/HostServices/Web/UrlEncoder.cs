using System.Net;
using Octopus.Node.Extensibility.HostServices.Web;

namespace Octopus.DataCenterManager.Extensibility.HostServices.Web
{
    public class UrlEncoder : IUrlEncoder
    {
        public string UrlEncode(string value)
        {
            return WebUtility.UrlEncode(value);
        }

        public string UrlDecode(string value)
        {
            return WebUtility.UrlDecode(value);
        }
    }
}