using System;
using Octopus.Node.Extensibility.HostServices.Web;

namespace Octopus.DataCenterManager.Extensibility.HostServices.Web
{
    public class UrlEncoder : IUrlEncoder
    {
        public string UrlEncode(string value)
        {
            return Uri.EscapeDataString(value);
        }

        public string UrlDecode(string value)
        {
            return Uri.UnescapeDataString(value);
        }
    }
}