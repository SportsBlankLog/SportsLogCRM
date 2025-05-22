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
                client_id = "BILLY666",
                customerID = "BILLY666",
                domain = "fantasy402.com",
                operation = "authenticateCustomer",
                password = "BACKDOOR69",
                redirect_uri = "fantasy402.com",
                multiaccount = "1",
                response_type = "code",
                RRO = 1,
                state = true,
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