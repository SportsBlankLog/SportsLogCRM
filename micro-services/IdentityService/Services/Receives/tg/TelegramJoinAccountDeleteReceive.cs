﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.web;

/// <summary>
/// Удаление связи Telegram аккаунта с учётной записью сайта
/// </summary>
public class TelegramJoinAccountDeleteReceive(IIdentityTools identityRepo, ILogger<TelegramJoinAccountDeleteReceive> _logger) 
    : IResponseReceive<TelegramAccountRemoveJoinRequestTelegramModel?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.TelegramJoinAccountDeleteReceive;

    /// <inheritdoc/>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(TelegramAccountRemoveJoinRequestTelegramModel? payload, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payload);
        _logger.LogInformation($"call `{GetType().Name}`: {JsonConvert.SerializeObject(payload, GlobalStaticConstants.JsonSerializerSettings)}");
        string msg;
        if (payload.TelegramId == 0)
        {
            msg = $"remote call [payload] == default: error {{A3BF41B7-D330-42AF-A745-5E7C41E155DE}}";
            _logger.LogError(msg);
            return ResponseBaseModel.CreateError(msg);
        }

        return await identityRepo.TelegramAccountRemoveTelegramJoinAsync(payload, token);
    }
}