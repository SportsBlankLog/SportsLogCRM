////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.SportsLog;

/// <summary>
/// DownloadAndSaveReceive
/// </summary>
public class DownloadAndSaveReceive(ISportsLogService sportsLogRepo)
    : IResponseReceive<BodyRequestSportsLogModel?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.DownloadAndSaveSportsLogReceive;

    /// <inheritdoc/>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(BodyRequestSportsLogModel? payload = null, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payload);
        return await sportsLogRepo.DownloadAndSaveAsync(payload, token);
    }
}