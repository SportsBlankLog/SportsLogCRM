﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.helpdesk;

/// <summary>
/// PulseJournalReceive - of context user
/// </summary>
public class PulseJournalSelectReceive(IHelpdeskService hdRepo)
    : IResponseReceive<TAuthRequestModel<TPaginationRequestModel<UserIssueModel>>?, TResponseModel<TPaginationResponseModel<PulseViewModel>>?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstants.TransmissionQueues.PulseJournalHelpdeskSelectReceive;

    /// <summary>
    /// PulseJournalReceive - of context user
    /// </summary>
    public async Task<TResponseModel<TPaginationResponseModel<PulseViewModel>>?> ResponseHandleAction(TAuthRequestModel<TPaginationRequestModel<UserIssueModel>>? req, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(req);
        return await hdRepo.PulseJournalSelect(req, token);
    }
}