using System;

namespace Octopus.Server.Extensibility.HostServices.Model.IssueTrackers
{
    public class WorkItem : IEquatable<WorkItem>
    {
        public string Id { get; set; }
        public string IssueTrackerId { get; set; }
        public string LinkUrl { get; set; }
        public string LinkText { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((WorkItem) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }

        public bool Equals(WorkItem other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Id, other.Id);
        }
    }
}