﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.constructor;

/// <summary>
/// ReadDirectoriesReceive
/// </summary>
public class ReadDirectoriesReceive(IConstructorService conService) : IResponseReceive<int[]?, List<EntryNestedModel>?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.ReadDirectoriesReceive;

    /// <inheritdoc/>
    public async Task<List<EntryNestedModel>?> ResponseHandleActionAsync(int[]? payload, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(payload);
        return await conService.ReadDirectoriesAsync(payload, token);
    }
}