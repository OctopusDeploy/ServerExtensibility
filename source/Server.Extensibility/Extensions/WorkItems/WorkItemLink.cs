using System;
using System.Text.RegularExpressions;

namespace Octopus.Server.Extensibility.Extensions.WorkItems;

public class WorkItemLink : IEquatable<WorkItemLink>, IComparable<WorkItemLink>
{
    static readonly Regex LastNumberRegex = new(@"(\d+)$", RegexOptions.Compiled);

    public string Id { get; set; } = string.Empty;
    public string LinkUrl { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int CompareTo(WorkItemLink? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        var thisIdMatch = LastNumberRegex.Match(Id);
        var otherIdMatch = LastNumberRegex.Match(other.Id);
        if (thisIdMatch.Success && otherIdMatch.Success)
            return int.Parse(thisIdMatch.Groups[1].Value) - int.Parse(otherIdMatch.Groups[1].Value);
        return string.Compare(Id, other.Id, StringComparison.OrdinalIgnoreCase);
    }

    public bool Equals(WorkItemLink? other)
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
        return Equals((WorkItemLink)obj);
    }

    public override int GetHashCode()
    {
        return Id != null ? Id.ToUpperInvariant().GetHashCode() : 0;
    }
}