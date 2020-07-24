using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Octopus.Server.Extensibility.Tests
{
    /// <summary>
    /// This class is designed to form the base for tests in the extensions/module world, where all classes other than
    ///     the entry point should be private, unless there's a really good reason.
    ///     The entry class will be either an IOctopusExtension or a straight Autofac Module, depending on whether it's
    ///     an extension or module respectively under test.
    /// </summary>
    [TestFixture]
    public abstract class OnlyExposeWhatIsNecessaryFixture
    {
        protected abstract Type EntryPointTypeUnderTest { get; }

        protected virtual IEnumerable<Type> KnownClassesWhoAreBendingTheRules => Enumerable.Empty<Type>();

        [Test]
        public void ServerExtensionsShouldMinimiseWhatIsExposed()
        {
            var assembly = EntryPointTypeUnderTest.Assembly;

            // get all public types other than the module itself, which is allowed to be public
            var allPublicThings = assembly.GetExportedTypes()
                                          .Where(t => t != EntryPointTypeUnderTest)
                                          .Select(t => t.FullName);

            var publicThingsThatShouldNotBe =
                allPublicThings.Except(KnownClassesWhoAreBendingTheRules.Select(t => t.FullName)).ToArray();
            if (publicThingsThatShouldNotBe.Any())
            {
                Console.WriteLine("The following classes are public, but are not expected to be:");
                foreach (var publicThingThatShouldNotBe in publicThingsThatShouldNotBe)
                    Console.WriteLine(publicThingThatShouldNotBe);
            }

            publicThingsThatShouldNotBe.Should().BeEmpty("Unexpected types are public");
        }
    }
}