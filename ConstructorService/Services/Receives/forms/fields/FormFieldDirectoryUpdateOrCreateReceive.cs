﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.constructor;

/// <summary>
/// Обновить/создать поле формы (тип: справочник/список)
/// </summary>
public class FormFieldDirectoryUpdateOrCreateReceive(IConstructorService conService) : IResponseReceive<TAuthRequestModel<FieldFormAkaDirectoryConstructorModelDB>?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstants.TransmissionQueues.FormFieldDirectoryUpdateOrCreateReceive;

    /// <inheritdoc/>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(TAuthRequestModel<FieldFormAkaDirectoryConstructorModelDB>? payload, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payload);
        return await conService.FormFieldDirectoryUpdateOrCreate(payload, token);
    }
}