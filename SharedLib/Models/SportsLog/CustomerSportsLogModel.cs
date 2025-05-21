////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// CustomerSportsLogModel
/// </summary>
public class CustomerSportsLogModel
{
    /// <inheritdoc/>
    public string? MasterAgent { get; set; }

    /// <inheritdoc/>
    public string? CustomerID { get; set; }

    /// <inheritdoc/>
    public string? AgentID { get; set; }

    /// <inheritdoc/>
    public int CasinoBalance { get; set; }

    /// <inheritdoc/>
    public string? SuspendHorses { get; set; }

    /// <inheritdoc/>
    public string? SuspendSportsbook { get; set; }

    /// <inheritdoc/>
    public string? Name { get; set; }

    /// <inheritdoc/>
    public string? Password { get; set; }

    /// <inheritdoc/>
    public int CurrentBalance { get; set; }

    /// <inheritdoc/>
    public int CreditLimit { get; set; }

    /// <inheritdoc/>
    public int WagerLimit { get; set; }

    /// <inheritdoc/>
    public string? CasinoActive { get; set; }

    /// <inheritdoc/>
    public string? SportbookActive { get; set; }

    /// <inheritdoc/>
    public int SettleFigure { get; set; }

    /// <inheritdoc/>
    public int TempCreditAdj { get; set; }

    /// <inheritdoc/>
    public int PendingWagerBalance { get; set; }

    /// <inheritdoc/>
    public int AvailableBalance { get; set; }

    /// <inheritdoc/>
    public string? Login { get; set; }

    /// <inheritdoc/>
    public string? ReadOnlyFlag { get; set; }

    /// <inheritdoc/>
    public string? Active { get; set; }

    /// <inheritdoc/>
    public string? AgentLogin { get; set; }

    /// <inheritdoc/>
    public string? AgentType { get; set; }

    /// <inheritdoc/>
    public int FreePlayBalance { get; set; }

    /// <inheritdoc/>
    public int ParlayMaxBet { get; set; }

    /// <inheritdoc/>
    public int ParlayMaxPayout { get; set; }

    /// <inheritdoc/>
    public int TeaserMaxBet { get; set; }

    /// <inheritdoc/>
    public int ContestMaxBet { get; set; }

    /// <inheritdoc/>
    public int MaxContestPrice { get; set; }

    /// <inheritdoc/>
    public int MaxPropPayout { get; set; }

    /// <inheritdoc/>
    public int MaxSoccerBet { get; set; }

    /// <inheritdoc/>
    public int MaxMoneyLine { get; set; }

    /// <inheritdoc/>
    public DateTime? LastVerDateTime { get; set; }

    /// <inheritdoc/>
    public string? SuspectedBot { get; set; }

    /// <inheritdoc/>
    public string? OpenDateTime { get; set; }

    /// <inheritdoc/>
    public string? Phone { get; set; }

    /// <inheritdoc/>
    public string? Email { get; set; }

    /// <inheritdoc/>
    public string? PlayerNotes { get; set; }

    /// <inheritdoc/>
    public int? SuspectedBotType { get; set; }
}