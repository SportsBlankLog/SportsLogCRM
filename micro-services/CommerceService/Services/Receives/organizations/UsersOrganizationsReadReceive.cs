﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using RemoteCallLib;
using SharedLib;

namespace Transmission.Receives.commerce;

/// <summary>
/// UsersOrganizationsReadReceive
/// </summary>
public class UsersOrganizationsReadReceive(ICommerceService commerceRepo) : IResponseReceive<int[]?, TResponseModel<UserOrganizationModelDB[]>?>
{
    /// <inheritdoc/>
    public static string QueueName => GlobalStaticConstantsTransmission.TransmissionQueues.OrganizationsUsersReadCommerceReceive;

    /// <inheritdoc/>
    public async Task<TResponseModel<UserOrganizationModelDB[]>?> ResponseHandleActionAsync(int[]? req, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(req);
        return await commerceRepo.UsersOrganizationsReadAsync(req, token);
    }
}