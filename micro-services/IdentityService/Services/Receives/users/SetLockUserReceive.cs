﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.Identity;

/// <summary>
/// Установить блокировку пользователю
/// </summary>
public class SetLockUserReceive(IIdentityTools idRepo, ILogger<SetLockUserReceive> loggerRepo)
    : IResponseReceive<IdentityBooleanModel?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.SetLockUserReceive;

    /// <summary>
    /// Установить блокировку пользователю
    /// </summary>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(IdentityBooleanModel? req, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(req);
        loggerRepo.LogWarning(JsonConvert.SerializeObject(req, GlobalStaticConstants.JsonSerializerSettings));
        return await idRepo.SetLockUserAsync(req, token);
    }
}