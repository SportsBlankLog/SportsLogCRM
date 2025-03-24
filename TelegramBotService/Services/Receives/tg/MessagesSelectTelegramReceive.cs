﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.telegram;

/// <summary>
/// Получить сообщения из чата
/// </summary>
public class MessagesSelectTelegramReceive(ITelegramBotService tgRepo)
    : IResponseReceive<TPaginationRequestModel<SearchMessagesChatModel>?, TPaginationResponseModel<MessageTelegramModelDB>?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstants.TransmissionQueues.MessagesChatsSelectTelegramReceive;

    /// <inheritdoc/>
    public async Task<TPaginationResponseModel<MessageTelegramModelDB>?> ResponseHandleActionAsync(TPaginationRequestModel<SearchMessagesChatModel>? req, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(req);
        return await tgRepo.MessagesSelectTelegram(req, token);
    }
}