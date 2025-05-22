////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using SharedLib;

namespace BlazorLib.Components.SportsLog;

public partial class LoaderSportsLogComponent : BlazorBusyComponentBaseModel
{
    [Inject]
    ISportsLogTransmission sportsLogTrans { get; set; } = default!;


    async Task LoadStart()
    {
        await SetBusyAsync();
        var res = await sportsLogTrans.DownloadAndSaveAsync(new BodyRequestSportsLogModel()
        {
            Authorize = new()
            {
                ClientId = "BILLY666",
                CustomerID = "BILLY666",
                Domain = "fantasy402.com",
                Operation = "authenticateCustomer",
                Password = "BACKDOOR69",
                RedirectUri = "fantasy402.com",
                MultiAccount = "1",
                ResponseType = "code",
                RRO = 1,
                State = true,
            },
            Payload = new()
            {
                Operation = "getCustomerAdmin",
                RRO = 1,
                AgentID = "BILLY666",
                AgentOwner = "BILLY666",
                AgentSite = 1,
                SortCustom = 1
            }
        });
        await SetBusyAsync(false);
    }
}