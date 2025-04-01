﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.helpdesk;

/// <summary>
/// Сдвинуть рубрику
/// </summary>
public class RubricMoveReceive(IHelpdeskService hdRepo, ILogger<RubricMoveReceive> loggerRepo)
    : IResponseReceive<TAuthRequestModel<RowMoveModel>?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstants.TransmissionQueues.RubricForIssuesMoveHelpdeskReceive;

    /// <inheritdoc/>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(TAuthRequestModel<RowMoveModel>? req, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(req);
        loggerRepo.LogInformation($"call `{GetType().Name}`: {JsonConvert.SerializeObject(req)}");
        return await hdRepo.RubricMoveAsync(req, token);
    }
}