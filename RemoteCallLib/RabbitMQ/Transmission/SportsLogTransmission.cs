////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using SharedLib;

namespace RemoteCallLib;

/// <summary>
/// SportsLogTransmission
/// </summary>
public partial class SportsLogTransmission(IRabbitClient rabbitClient) : ISportsLogTransmission
{
    /// <inheritdoc/>
    public async Task<ResponseBaseModel> DownloadAndSaveAsync(BodyRequestSportsLogModel req, CancellationToken token = default)
        => await rabbitClient.MqRemoteCallAsync<ResponseBaseModel>(GlobalStaticConstantsTransmission.TransmissionQueues.DownloadAndSaveSportsLogReceive, req, token: token) ?? new();
}
