////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using System.ComponentModel.DataAnnotations;

namespace SharedLib;

/// <summary>
/// CustomerSportsLogModelDB
/// </summary>
public class CustomerSportsLogModelDB : CustomerSportsLogModel
{
    /// <inheritdoc/>
    [Key]
    public int Id { get; set; }

    /// <inheritdoc/>
    public DateTime ImportedAt { get; set; }

    /// <inheritdoc/>
    public DateTime LastUpdateddAt { get; set; }
}