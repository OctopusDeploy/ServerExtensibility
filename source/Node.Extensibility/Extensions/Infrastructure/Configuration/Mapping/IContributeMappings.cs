using Octopus.Data.Model;
using Octopus.Data.Resources;

namespace Octopus.Node.Extensibility.Extensions.Infrastructure.Configuration
{
    public interface IContributeMappings
    {
        IResourceMapping GetMapping();
    }


    public class FooConfigStore : IContributeMappings
    {
        private readonly IResourceMappingFactory factory;

        public FooConfigStore(IResourceMappingFactory factory)
        {
            this.factory = factory;
        }

        public IResourceMapping GetMapping()
        {
            var mapping = factory.Create<ResourceFoo, ModelFoo>()
                .DoNotMap(r => r.Bar);

            return mapping;
        }

        //private List<Expression<Func<TModel, TProperty>>>

        //donotmap -> materialize the propertyname and add to an internal collection? Can't generically store the lambdas I don't think

        //
    }

    public class ModelFoo
    {
        public string Bar { get; set; }
    }

    public class ResourceFoo : IResource
    {
        public string Bar { get; set; }

        public string Id { get; }

        public LinkCollection Links { get; set; }
    }

}