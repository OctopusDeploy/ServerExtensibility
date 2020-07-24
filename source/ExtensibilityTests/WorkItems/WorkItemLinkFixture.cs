using System;
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
                new WorkItemLink { Id = "test1" }
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
                new WorkItemLink { Id = "Test1" }
            };

            var distinctWorkItems = listWithDupes.Distinct();

            Assert.AreEqual(2, distinctWorkItems.Count());
        }

        [Test]
        public void WorkItemsSortByNumericId()
        {
            var workItemLinks = new List<WorkItemLink>
            {
                new WorkItemLink { Id = "34" },
                new WorkItemLink { Id = "5" },
                new WorkItemLink { Id = "987" }
            };
            Assert.AreEqual("5,34,987",
                            string.Join(",", workItemLinks.OrderBy(x => x).Select(x => x.Id)));
        }

        [Test]
        public void WorkItemsSortByPrefixedNumber()
        {
            var workItemLinks = new List<WorkItemLink>
            {
                new WorkItemLink { Id = "JIR7-34" },
                new WorkItemLink { Id = "JIR7-5" },
                new WorkItemLink { Id = "JIR7-987" }
            };
            Assert.AreEqual("JIR7-5,JIR7-34,JIR7-987",
                            string.Join(",", workItemLinks.OrderBy(x => x).Select(x => x.Id)));
        }
    }
}