using System;

namespace Octopus.Server.Extensibility.Resources.IssueTrackers
{
    public class CommitDetails : IEquatable<CommitDetails>
    {
        public string Id { get; set; }
        public string LinkUrl { get; set; }
        public string Comment { get; set; }

        public bool Equals(CommitDetails other)
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
            return Equals((CommitDetails) obj);
        }

        public override int GetHashCode()
        {
            return (Id != null ? Id.GetHashCode() : 0);
        }
    }
}