using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Server.Extensibility.Tests
{
    /// <summary>
    /// This class is designed to form the base for tests in the extentions/module world, where all classes other than
    /// the entry point should be private, unless there's a really good reason.
    /// The entry class will be either an IOctopusExtension or a straight Autofac Module, depending on whether it's
    /// an extension or module respectively under test.
    /// </summary>
    [TestFixture]
    public abstract class OnlyExposeWhatIsNecessaryFixture
    {
        protected abstract Type EntryPointTypeUnderTest { get; }
        
        protected abstract IEnumerable<string> KnownClassesWhoAreBendingTheRules { get; }
        
        [Test]
        public void ServerExtensionsShouldMinimiseWhatIsExposed()
        {
            var assembly = EntryPointTypeUnderTest.Assembly;

            // get all public types other than the module itself, which is allowed to be public
            var allPublicThings = assembly.GetExportedTypes()
                .Where(t => t != EntryPointTypeUnderTest)
                .Select(t => t.FullName);

            var publicThingsThatShouldNotBe = allPublicThings.Except(KnownClassesWhoAreBendingTheRules).ToArray();
            if (publicThingsThatShouldNotBe.Any())
            {
                Console.WriteLine("The following classes are public, but are not expected to be:");
                foreach (var publicThingThatShouldNotBe in publicThingsThatShouldNotBe)
                {
                    Console.WriteLine(publicThingsThatShouldNotBe);
                }
            }

            publicThingsThatShouldNotBe.Should().BeEmpty();
        }
    }
}