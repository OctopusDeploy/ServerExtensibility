using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using Octopus.Server.Extensibility.Extensions.Infrastructure.Configuration;

namespace Node.Extensibility.Tests.Extensions.Infrastructure.Configuration
{
    [TestFixture]
    public class ConfigurationValueFixture
    {
        [Test]
        public void EnumValuesShouldBeSerializedAsStrings()
        {
            var toSerialize = new ConfigurationValue<SomeEnum>("Some.Key", SomeEnum.SomeEnumValue, true, "Some description");

            var serialized = JsonConvert.SerializeObject(toSerialize);

            serialized.Should().Be("{\"Key\":\"Some.Key\",\"Value\":\"SomeEnumValue\",\"ShowInPortalSummary\":true,\"Description\":\"Some description\",\"IsSensitive\":false}");
        }

        private enum SomeEnum
        {
            SomeEnumValue
        }
    }
}