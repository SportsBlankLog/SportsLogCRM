﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.helpdesk;

/// <summary>
/// Subscribe update - of context user
/// </summary>
public class SubscribeUpdateReceive(IHelpDeskService hdRepo) : IResponseReceive<TAuthRequestModel<SubscribeUpdateRequestModel>?, TResponseModel<bool?>?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.SubscribeIssueUpdateHelpDeskReceive;

    /// <inheritdoc/>
    public async Task<TResponseModel<bool?>?> ResponseHandleActionAsync(TAuthRequestModel<SubscribeUpdateRequestModel>? req, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(req);
        return await hdRepo.SubscribeUpdateAsync(req, token);
    }
}