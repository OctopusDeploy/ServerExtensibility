namespace Octopus.Server.Extensibility.HostServices.Model
{
    public interface ISpaceScopedDocument : IDocument
    {
        string SpaceId { get; }
    }
}