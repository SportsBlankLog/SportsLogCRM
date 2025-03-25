﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using BlazorLib;
using SharedLib;

namespace BlazorWebLib.Components.Commerce.Attendances;

/// <summary>
/// WorkCalendarAddDateComponent
/// </summary>
public partial class WorkCalendarAddDateComponent : BlazorBusyComponentBaseAuthModel
{
    /// <summary>
    /// Commerce
    /// </summary>
    [Inject]
    protected ICommerceTransmission CommerceRepo { get; set; } = default!;


    /// <summary>
    /// WorkCalendarAddDateHandle
    /// </summary>
    [Parameter]
    public Action? WorkCalendarAddDateHandle { get; set; }


    bool IsExpanded;
    private DateTime? _date = DateTime.Today;

    /// <summary>
    /// StartPart
    /// </summary>
    TimeSpan? StartPart = new(09, 00, 00);

    /// <summary>
    /// EndPart
    /// </summary>
    TimeSpan? EndPart = new(18, 00, 00);

    uint QueueCapacity;

    async Task Save()
    {
        if (_date is null || EndPart is null || StartPart is null || CurrentUserSession is null)
            return;

        await SetBusy();
        TResponseModel<int> res = await CommerceRepo.CalendarScheduleUpdateAsync(new()
        {
            Payload = new CalendarScheduleModelDB()
            {
                DateScheduleCalendar = DateOnly.FromDateTime(_date.Value),
                EndPart = EndPart.Value,
                StartPart = StartPart.Value,
                QueueCapacity = QueueCapacity,
                Name = "",
                ContextName = GlobalStaticConstants.Routes.ATTENDANCES_CONTROLLER_NAME,
                IsDisabled = true,
            },
            SenderActionUserId = CurrentUserSession.UserId
        });
        await SetBusy(false);
        if (WorkCalendarAddDateHandle is not null)
            WorkCalendarAddDateHandle();
    }
}