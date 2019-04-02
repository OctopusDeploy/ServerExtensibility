
namespace Octopus.Server.Extensibility.HostServices.Model.Projects
{
    public interface IProvideProjectSettingsValues
    {
        T GetSettings<T>(string extensionId, string projectId);
    }
}