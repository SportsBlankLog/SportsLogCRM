////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// BodyRequestSportsLogModel
/// </summary>
public class BodyRequestSportsLogModel
{
    /// <inheritdoc/>
    public required RequestSportsLogModel Payload { get; set; }

    /// <inheritdoc/>
    public required AuthenticateCustomerRequestModel Authorize { get; set; }
}