namespace Octopus.Server.Extensibility.HostServices.Domain
{
    public interface IStore<out TDocument>
        where TDocument : class
    {
        TDocument Get(string id);
    }
}