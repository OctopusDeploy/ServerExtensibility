using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Octopus.Server.Extensibility.Resources.IssueTrackers;

namespace Node.Extensibility.Tests.WorkItems
{
    [TestFixture]
    public class WorkItemLinkFixture
    {
        [Test]
        public void DistinctWorkItemsBehavesCorrectly()
        {
            var listWithDupes = new List<WorkItemLink>
            {
                new WorkItemLink { Id = "test1" },
                new WorkItemLink { Id = "test2" },
                new WorkItemLink { Id = "test1" },
            };

            var distinctWorkItems = listWithDupes.Distinct();

            Assert.AreEqual(2, distinctWorkItems.Count());
        }

        [Test]
        public void DistinctWorkItemsBehavesCorrectlyWithDifferentCasing()
        {
            var listWithDupes = new List<WorkItemLink>
            {
                new WorkItemLink { Id = "test1" },
                new WorkItemLink { Id = "test2" },
                new WorkItemLink { Id = "Test1" },
            };

            var distinctWorkItems = listWithDupes.Distinct();

            Assert.AreEqual(2, distinctWorkItems.Count());
        }
    }
}