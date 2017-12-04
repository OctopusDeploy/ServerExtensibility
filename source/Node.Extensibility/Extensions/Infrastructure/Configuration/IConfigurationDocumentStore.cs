using Nevermore.Contracts;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IConfigurationDocumentStore<TConfiguration> : IConfigurationDocumentStore
        where TConfiguration : class, IId
    {
        
    }

    public interface IConfigurationDocumentStore
    {
        object GetConfiguration();
        void SetConfiguration(object config);
    }
}