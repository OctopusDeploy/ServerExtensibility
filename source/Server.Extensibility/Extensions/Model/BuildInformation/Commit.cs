using System;

namespace Octopus.Server.Extensibility.Extensions.Model.BuildInformation;

public class Commit : IEquatable<Commit>
{
    public string Id { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
    public DateTimeOffset? Committed { get; set; }

    public bool Equals(Commit? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return string.Equals(Id, other.Id, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != GetType()) return false;
        return Equals((Commit)obj);
    }

    public override int GetHashCode()
    {
        return Id != null ? Id.ToUpperInvariant().GetHashCode() : 0;
    }
}