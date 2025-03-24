﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// string Id
/// <code>AND</code>
/// string? Name
/// </summary>
public class EntryAltModel
{
    /// <inheritdoc/>
    public required string Id { get; set; }

    /// <inheritdoc/>
    public required string? Name { get; set; }

    /// <inheritdoc/>
    public static EntryAltModel Build(string id, string name) => new() { Id = id, Name = name };

    /// <inheritdoc/>
    public void Update(EntryAltModel other)
    {
        Id = other.Id;
        Name = other.Name;
    }

    /// <inheritdoc/>
    public static bool operator ==(EntryAltModel e1, EntryAltModel e2)
        => e1.Id == e2.Id && e1.Name == e2.Name;

    /// <inheritdoc/>
    public static bool operator !=(EntryAltModel e1, EntryAltModel e2)
        => e1.Id != e2.Id || e1.Name != e2.Name;

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj is EntryAltModel _e)
            return _e.Id == Id && _e.Name == Name;

        return false;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return $"{Id} {Name}".GetHashCode();
    }
}