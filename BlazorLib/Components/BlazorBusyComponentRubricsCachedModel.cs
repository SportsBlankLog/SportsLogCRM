﻿////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using MudBlazor;
using SharedLib;

namespace BlazorLib;

/// <summary>
/// BlazorBusyComponentRubricsCachedModel
/// </summary>
public abstract class BlazorBusyComponentRubricsCachedModel : BlazorBusyComponentBaseModel
{
    /// <summary>
    /// Commerce
    /// </summary>
    [Inject]
    protected ICommerceTransmission CommerceRepo { get; set; } = default!;

    /// <summary>
    /// Helpdesk
    /// </summary>
    [Inject]
    protected IHelpdeskTransmission HelpdeskRepo { get; set; } = default!;


    /// <summary>
    /// RubricsCache
    /// </summary>
    protected List<RubricIssueHelpdeskModelDB> RubricsCache = [];


    /// <summary>
    /// CacheRubricsUpdate
    /// </summary>
    protected async Task CacheRubricsUpdate(IEnumerable<int> rubricsIds)
    {
        rubricsIds = rubricsIds.Where(x => x > 0 && !RubricsCache.Any(y => y.Id == x)).Distinct();
        if (!rubricsIds.Any())
            return;

        await SetBusy();
        TResponseModel<List<RubricIssueHelpdeskModelDB>> rubrics = await HelpdeskRepo.RubricsGetAsync(rubricsIds);
        SnackbarRepo.ShowMessagesResponse(rubrics.Messages);
        if (rubrics.Success() && rubrics.Response is not null && rubrics.Response.Count != 0)
            lock (RubricsCache)
            {
                RubricsCache.AddRange(rubrics.Response.Where(x => !RubricsCache.Any(y => y.Id == x.Id)));
            }

        await SetBusy(false);
    }
}