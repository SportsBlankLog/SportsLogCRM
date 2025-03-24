﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.constructor;

/// <summary>
/// Обновить/создать связь [таба/вкладки схемы документа] с [формой]
/// </summary>
public class CreateOrUpdateTabDocumentSchemeJoinFormReceive(IConstructorService conService) : IResponseReceive<TAuthRequestModel<FormToTabJoinConstructorModelDB>?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstants.TransmissionQueues.CreateOrUpdateTabDocumentSchemeJoinFormReceive;

    /// <inheritdoc/>
    public async Task<ResponseBaseModel?> ResponseHandleActionAsync(TAuthRequestModel<FormToTabJoinConstructorModelDB>? payload, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payload);
        return await conService.CreateOrUpdateTabDocumentSchemeJoinFormAsync(payload, token);
    }
}
