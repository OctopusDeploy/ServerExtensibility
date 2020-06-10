using System;
using NUnit.Framework;
using Octopus.Server.Extensibility.HostServices.Model.TagSets;

namespace Node.Extensibility.Tests.Tags
{
    public class TagsCanonicalIdsOrNamesFixture
    {
        [Test]
        [TestCase("TagSet-1/Tag-1")]
        [TestCase("SomeTagSet/SomeTagName")]
        public void ShouldAcceptValidInputs(string tagCanonicalIdOrName)
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.DoesNotThrow(() => new TagCanonicalId(tagCanonicalIdOrName));
            Assert.DoesNotThrow(() => new TagCanonicalName(tagCanonicalIdOrName));
            Assert.DoesNotThrow(() => new TagCanonicalIdOrName(tagCanonicalIdOrName));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("/")]
        [TestCase("//")]
        [TestCase("TagSet-1/Tag-1/")]
        [TestCase("TagSet-1//Tag-1")]
        [TestCase("/TagSet-1/Tag-1")]
        [TestCase("/TagSet-1")]
        [TestCase("TagSet-1/")]
        public void ShouldThrowForInvalidInputs(string tagCanonicalIdOrName)
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new TagCanonicalId(tagCanonicalIdOrName));
            Assert.Throws<ArgumentException>(() => new TagCanonicalName(tagCanonicalIdOrName));
            Assert.Throws<ArgumentException>(() => new TagCanonicalIdOrName(tagCanonicalIdOrName));
        }
    }
}