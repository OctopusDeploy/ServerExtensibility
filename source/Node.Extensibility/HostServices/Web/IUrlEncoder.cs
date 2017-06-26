namespace Octopus.Node.Extensibility.HostServices.Web
{
    public interface IUrlEncoder
    {
        string UrlEncode(string value);

        string UrlDecode(string value);
    }
}