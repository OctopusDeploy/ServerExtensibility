using Octopus.Data.Model;
using Octopus.Data.Resources;
using Octopus.Node.Extensibility.Mapping;

namespace Octopus.Node.Extensibility.Mapping
{
    public interface IContributeMappings
    {
        IResourceMapping GetMapping();
    }


    public class FooConfigStore : IContributeMappings
    {
        private readonly IResourceMappingFactory factory;
        private readonly IAcceptMappings mapper;

        public FooConfigStore(IResourceMappingFactory factory, IAcceptMappings mapper)
        {
            this.factory = factory;
            this.mapper = mapper;
        }

        public IResourceMapping GetMapping()
        {
            mapper.Map<ResourceFoo, ModelFoo>()
                .DoNotMap(r => r.Bar)
                .EnrichModel((model, resource) =>
                {
                    model.Bar = resource.Bar;
                });

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