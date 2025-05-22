////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;

namespace SharedLib;

/// <summary>
/// AuthenticateCustomerRequestModel
/// </summary>
public class AuthenticateCustomerRequestModel
{
    /// <inheritdoc/>
    [JsonProperty("customerID")]
    public required string CustomerID { get; set; }

    /// <inheritdoc/>
    [JsonProperty("state")]
    public bool State { get; set; }

    /// <inheritdoc/>
    public required string Password { get; set; }

    /// <inheritdoc/>
    [JsonProperty("multiaccount")]
    public string? MultiAccount { get; set; } // "1"

    /// <inheritdoc/>
    [JsonProperty("response_type")]
    public string ResponseType { get; set; } = "code";

    /// <inheritdoc/>
    [JsonProperty("client_id")]
    public required string ClientId { get; set; }

    /// <inheritdoc/>
    [JsonProperty("domain")]
    public required string Domain { get; set; }

    /// <inheritdoc/>
    [JsonProperty("redirect_uri")]
    public required string RedirectUri { get; set; }

    /// <inheritdoc/>
    [JsonProperty("operation")]
    public required string Operation { get; set; }

    /// <inheritdoc/>
    public int RRO { get; set; }
}