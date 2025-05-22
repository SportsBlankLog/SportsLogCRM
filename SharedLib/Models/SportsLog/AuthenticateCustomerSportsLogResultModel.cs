////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;

namespace SharedLib;

/// <summary>
/// AuthenticateCustomerSportsLogResultModel
/// </summary>
public partial class AuthenticateCustomerSportsLogResultModel
{
    /// <inheritdoc/>
    [JsonProperty("accountInfo")]
    public AccountInfoSportsLogModel? AccountInfo { get; set; }

    /// <inheritdoc/>
    [JsonProperty("code")]
    public string? Code { get; set; }
}
