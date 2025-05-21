////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// ISportsLogService
/// </summary>
public interface ISportsLogService
{
    /// <inheritdoc/>
    public Task<ResponseBaseModel> DownloadAndSaveAsync(CancellationToken token = default);
}