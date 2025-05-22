////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SharedLib;

/// <summary>
/// AccountInfoSportsLogModel
/// </summary>
public partial class AccountInfoSportsLogModel
{
    /// <inheritdoc/>
    [JsonProperty("customerID")]
    public string? CustomerId { get; set; }

    /// <inheritdoc/>
    [JsonProperty("Active")]
    public string? Active { get; set; }

    /// <inheritdoc/>
    [JsonProperty("CasinoActive")]
    public string? CasinoActive { get; set; }

    /// <inheritdoc/>
    [JsonProperty("AllowPoker")]
    public string? AllowPoker { get; set; }

    /// <inheritdoc/>
    [JsonProperty("SuspendSportsbook")]
    public string? SuspendSportsbook { get; set; }

    /// <inheritdoc/>
    [JsonProperty("LiveCasinoActive")]
    public string? LiveCasinoActive { get; set; }

    /// <inheritdoc/>
    [JsonProperty("CreditLimit")]
    public long CreditLimit { get; set; }

    /// <inheritdoc/>
    [JsonProperty("Office")]
    public string? Office { get; set; }

    /// <inheritdoc/>
    [JsonProperty("CurrentBalance")]
    public long CurrentBalance { get; set; }

    /// <inheritdoc/>
    [JsonProperty("AvailableBalance")]
    public long AvailableBalance { get; set; }

    /// <inheritdoc/>
    [JsonProperty("PendingWagerBalance")]
    public long PendingWagerBalance { get; set; }

    /// <inheritdoc/>
    [JsonProperty("CurrencyCode")]
    public string? CurrencyCode { get; set; }

    /// <inheritdoc/>
    [JsonProperty("Currency")]
    public string? Currency { get; set; }

    /// <inheritdoc/>
    [JsonProperty("Store")]
    public string? Store { get; set; }

    /// <inheritdoc/>
    [JsonProperty("CustProfile")]
    public string? CustProfile { get; set; }

    /// <inheritdoc/>
    [JsonProperty("AgentID")]
    public object? AgentId { get; set; }

    /// <inheritdoc/>
    [JsonProperty("WagerLimit")]
    public long WagerLimit { get; set; }

    /// <inheritdoc/>
    [JsonProperty("DonotApplyCirleLimits")]
    public string? DonotApplyCirleLimits { get; set; }

    /// <inheritdoc/>
    [JsonProperty("ParlayName")]
    public string? ParlayName { get; set; }

    /// <inheritdoc/>
    [JsonProperty("CreditAcctFlag")]
    public string? CreditAcctFlag { get; set; }

    /// <inheritdoc/>
    [JsonProperty("PercentBook")]
    public long PercentBook { get; set; }

    /// <inheritdoc/>
    [JsonProperty("ContestMaxBet")]
    public long ContestMaxBet { get; set; }

    /// <inheritdoc/>
    [JsonProperty("FreePlayBalance")]
    public long FreePlayBalance { get; set; }

    /// <inheritdoc/>
    [JsonProperty("EasternLineFlag")]
    public string? EasternLineFlag { get; set; }

    /// <inheritdoc/>
    [JsonProperty("NotrueOdds")]
    public string? NotrueOdds { get; set; }

    /// <inheritdoc/>
    [JsonProperty("MaxContestPrice")]
    public long MaxContestPrice { get; set; }

    /// <inheritdoc/>
    [JsonProperty("NotrueOddsDiscount")]
    public long NotrueOddsDiscount { get; set; }

    /// <inheritdoc/>
    [JsonProperty("ParlayMaxPayout")]
    public long ParlayMaxPayout { get; set; }

    /// <inheritdoc/>
    [JsonProperty("ParlayMaxBet")]
    public long ParlayMaxBet { get; set; }

    /// <inheritdoc/>
    [JsonProperty("AgentType")]
    public string? AgentType { get; set; }

    /// <inheritdoc/>
    [JsonProperty("MaxIfBetReverse")]
    public JObject? MaxIfBetReverse { get; set; }

    /// <inheritdoc/>
    [JsonProperty("EnforceAccumWagerLimitsFlag")]
    public string? EnforceAccumWagerLimitsFlag { get; set; }

    /// <inheritdoc/>
    [JsonProperty("EnforceAccumWagerLimitsByLineFlag")]
    public JObject? EnforceAccumWagerLimitsByLineFlag { get; set; }

    /// <inheritdoc/>
    [JsonProperty("TeamLimit")]
    public long TeamLimit { get; set; }

    /// <inheritdoc/>
    [JsonProperty("maxRoundRobin")]
    public long MaxRoundRobin { get; set; }

    /// <inheritdoc/>
    [JsonProperty("Language")]
    public string? Language { get; set; }

    /// <inheritdoc/>
    [JsonProperty("WSBettingType")]
    public long WsBettingType { get; set; }

    /// <inheritdoc/>
    [JsonProperty("horseActive")]
    public string? HorseActive { get; set; }

    /// <inheritdoc/>
    [JsonProperty("DefaultSiteSkin")]
    public string? DefaultSiteSkin { get; set; }

    /// <inheritdoc/>
    [JsonProperty("OTPEnabled")]
    public long OtpEnabled { get; set; }

    /// <inheritdoc/>
    [JsonProperty("OTP")]
    public string? Otp { get; set; }

    /// <inheritdoc/>
    [JsonProperty("UseCaptcha")]
    public string? UseCaptcha { get; set; }

    /// <inheritdoc/>
    [JsonProperty("SuspectedBot")]
    public JObject? SuspectedBot { get; set; }

    /// <inheritdoc/>
    [JsonProperty("DomainRedirect")]
    public string? DomainRedirect { get; set; }

    /// <inheritdoc/>
    [JsonProperty("SkinOverride")]
    public string? SkinOverride { get; set; }

    /// <inheritdoc/>
    [JsonProperty("AgentSkinOverride")]
    public string? AgentSkinOverride { get; set; }
}