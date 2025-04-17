﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.Identity;

/// <summary>
/// Создает (и отправляет) токен изменения адреса электронной почты для указанного пользователя.
/// </summary>
public class GenerateChangeEmailTokenReceive(IIdentityTools idRepo, ILogger<GenerateChangeEmailTokenReceive> loggerRepo)
    : IResponseReceive<GenerateChangeEmailTokenRequestModel?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.GenerateChangeEmailTokenReceive;

    /// <summary>
    /// Создает (и отправляет) токен изменения адреса электронной почты для указанного пользователя.
    /// </summary>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(GenerateChangeEmailTokenRequestModel? req, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(req);
        loggerRepo.LogWarning(JsonConvert.SerializeObject(req, GlobalStaticConstants.JsonSerializerSettings));
        return await idRepo.GenerateChangeEmailTokenAsync(req, token);
    }
}