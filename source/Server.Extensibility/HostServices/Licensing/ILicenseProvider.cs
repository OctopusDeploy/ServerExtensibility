namespace Octopus.Server.Extensibility.HostServices.Licensing
{
    public interface ILicenseProvider
    {
        bool IsUsingCloudLicense();
    }
}