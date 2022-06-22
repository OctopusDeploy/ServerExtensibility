using System;

namespace Octopus.Server.Extensibility.Extensions.WorkItems;

public class CommitDetails : IEquatable<CommitDetails>
{
    public string Id { get; set; } = string.Empty;
    public string LinkUrl { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public DateTimeOffset? Committed { get; set; }

    public bool Equals(CommitDetails? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Id, other.Id);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((CommitDetails)obj);
    }

    public override int GetHashCode()
    {
        return Id != null ? Id.GetHashCode() : 0;
    }
}