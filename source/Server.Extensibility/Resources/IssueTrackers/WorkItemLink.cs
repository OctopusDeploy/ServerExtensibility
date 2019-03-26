using System;

namespace Octopus.Server.Extensibility.Resources.IssueTrackers
{
    public class WorkItemLink : IEquatable<WorkItemLink>
    {
        public string Id { get; set; }
        public string LinkUrl { get; set; }
        public string Description { get; set; }

        public bool Equals(WorkItemLink other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WorkItemLink) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}