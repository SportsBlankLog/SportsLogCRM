﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Newtonsoft.Json;
using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.storage;

/// <summary>
/// Set web config site
/// </summary>
public class SetWebConfigReceive(WebConfigModel webConfig, ILogger<SetWebConfigReceive> _logger) : IResponseReceive<WebConfigModel?, ResponseBaseModel?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstants.TransmissionQueues.SetWebConfigStorageReceive;

    /// <inheritdoc/>
    public Task<ResponseBaseModel?> ResponseHandleActionAsync(WebConfigModel? payload, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payload);
        _logger.LogInformation($"call `{GetType().Name}`: {JsonConvert.SerializeObject(payload)}");

#pragma warning disable CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
        if (!Uri.TryCreate(payload.BaseUri, UriKind.Absolute, out _))
            return Task.FromResult(ResponseBaseModel.CreateError("BaseUri is null"));

        return Task.FromResult(webConfig.Update(payload.BaseUri));
#pragma warning restore CS8619 // Допустимость значения NULL для ссылочных типов в значении не соответствует целевому типу.
    }
}