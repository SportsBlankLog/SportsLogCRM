////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// AuthenticateCustomerRequestModel
/// </summary>
public class AuthenticateCustomerRequestModel
{
    /// <inheritdoc/>
#pragma warning disable IDE1006 // Стили именования
    public required string customerID { get; set; }

    /// <inheritdoc/>
    public bool state { get; set; }

    /// <inheritdoc/>
    public required string password { get; set; }

    /// <inheritdoc/>
    public string? multiaccount { get; set; } // "1"

    /// <inheritdoc/>
    public string response_type { get; set; } = "code";

    /// <inheritdoc/>
    public required string client_id { get; set; }

    /// <inheritdoc/>
    public required string domain { get; set; }

    /// <inheritdoc/>
    public required string redirect_uri { get; set; }

    /// <inheritdoc/>
    public required string operation { get; set; }
#pragma warning restore IDE1006 // Стили именования

    /// <inheritdoc/>
    public int RRO { get; set; }
}