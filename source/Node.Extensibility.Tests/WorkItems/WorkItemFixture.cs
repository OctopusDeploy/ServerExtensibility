using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Octopus.Server.Extensibility.HostServices.Model.IssueTrackers;

namespace Node.Extensibility.Tests.WorkItems
{
    [TestFixture]
    public class WorkItemFixture
    {
        [Test]
        public void DistinctWorkItemsBehavesCorrectly()
        {
            var listWithDupes = new List<WorkItem>
            {
                new WorkItem { Id = "test1" },
                new WorkItem { Id = "test2" },
                new WorkItem { Id = "test1" },
            };

            var distinctWorkItems = listWithDupes.Distinct();

            Assert.AreEqual(2, distinctWorkItems.Count());
        }
    }
}