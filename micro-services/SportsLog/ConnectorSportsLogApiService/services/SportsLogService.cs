////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RemoteCallLib;
using SharedLib;
using DbcLib;
using static SharedLib.GlobalStaticConstantsRoutes;

namespace SportsLogService;

/// <summary>
/// SportsLog
/// </summary>
public class SportsLogService(IHttpClientFactory HttpClientFactory,
    ILogger<SportsLogService> logger,
    IDbContextFactory<SportsLogContext> dbFactory)
    : ISportsLogService
{
    /// <inheritdoc/>
    public async Task<ResponseBaseModel> DownloadAndSaveAsync(CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
}