////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <inheritdoc/>
public interface ISportsLogTransmission
{
    /// <summary>
    /// DownloadAndSaveAsync
    /// </summary>
    public Task<ResponseBaseModel> DownloadAndSaveAsync(BodyRequestSportsLogModel req, CancellationToken token = default);
}
