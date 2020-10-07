using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Octopus.Server.Extensibility.HostServices.Model.IssueTrackers;

namespace Node.Extensibility.Tests.WorkItems
{
    [TestFixture]
    public class CommitFixture
    {
        [Test]
        public void DistinctCommitsBehavesCorrectly()
        {
            var listWithDupes = new List<Commit>
            {
                new Commit { Id = "test1" },
                new Commit { Id = "test2" },
                new Commit { Id = "test1" }
            };

            var distinctWorkItems = listWithDupes.Distinct();

            Assert.AreEqual(2, distinctWorkItems.Count());
        }

        [Test]
        public void DistinctCommitsBehavesCorrectlyWithDifferentCasing()
        {
            var listWithDupes = new List<Commit>
            {
                new Commit { Id = "test1" },
                new Commit { Id = "test2" },
                new Commit { Id = "Test1" }
            };

            var distinctWorkItems = listWithDupes.Distinct();

            Assert.AreEqual(2, distinctWorkItems.Count());
        }
    }
}