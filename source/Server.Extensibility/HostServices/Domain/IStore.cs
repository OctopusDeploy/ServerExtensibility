namespace Octopus.Server.Extensibility.HostServices.Domain
{
    public interface IStore<out TDocument>
    {
        TDocument Get(string id);
    }
}