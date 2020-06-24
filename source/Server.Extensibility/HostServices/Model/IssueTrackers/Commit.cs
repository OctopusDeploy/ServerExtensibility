using System;

namespace Octopus.Server.Extensibility.HostServices.Model.IssueTrackers
{
    public class Commit : IEquatable<Commit>
    {
        public string Id { get; set; }
        public string Comment { get; set; }

        public bool Equals(Commit other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Id, other.Id, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Commit) obj);
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.ToUpperInvariant().GetHashCode() : 0;
        }
    }
}