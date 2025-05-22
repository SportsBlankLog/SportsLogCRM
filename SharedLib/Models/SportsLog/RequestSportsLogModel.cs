////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// RequestSportsLogModel
/// </summary>
public class RequestSportsLogModel
{
    /// <inheritdoc/>
    public required string Operation { get; set; }

    /// <inheritdoc/>
    public string? AgentID { get; set; }

    /// <inheritdoc/>
    public int? RRO { get; set; }

    /// <inheritdoc/>
    public string? AgentOwner { get; set; }

    /// <inheritdoc/>
    public int? AgentSite { get; set; }

    /// <inheritdoc/>
    public int? SortCustom { get; set; }
}