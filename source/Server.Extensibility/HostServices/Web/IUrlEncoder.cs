namespace Octopus.Server.Extensibility.HostServices.Web
{
    public interface IUrlEncoder
    {
        string UrlEncode(string value);

        string UrlDecode(string value);
    }
}