﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using BlazorLib;
using SharedLib;
using MudBlazor;

namespace BlazorWebLib.Components.Commerce;

/// <summary>
/// OfficesOrganizationComponent
/// </summary>
public partial class OfficesOrganizationComponent : BlazorBusyComponentBaseModel
{
    [Inject]
    IHelpdeskTransmission HelpdeskRepo { get; set; } = default!;

    [Inject]
    ICommerceTransmission CommerceRepo { get; set; } = default!;


    /// <summary>
    /// Organization
    /// </summary>
    [Parameter, EditorRequired]
    public required OrganizationModelDB Organization { get; set; }


    UniversalBaseModel? SelectedRubric;

    Dictionary<int, List<RubricIssueHelpdeskModelDB>> RubriciesCached = [];
    string? addingAddress, addingContacts, addingName;

    bool CanCreate =>
        !string.IsNullOrWhiteSpace(addingAddress) &&
        !string.IsNullOrWhiteSpace(addingContacts) &&
        !string.IsNullOrWhiteSpace(addingName) &&
        SelectedRubric is not null;

    bool _expanded;
    private void OnExpandCollapseClick()
    {
        _expanded = !_expanded;
    }

    async Task AddOffice()
    {
        if (!CanCreate)
            return;

        await SetBusy();

        TResponseModel<int> res = await CommerceRepo.OfficeOrganizationUpdate(new AddressOrganizationBaseModel()
        {
            Address = addingAddress!,
            Name = addingName!,
            ParentId = SelectedRubric!.Id,
            OrganizationId = Organization.Id,
            Contacts = addingContacts,
        });
        IsBusyProgress = false;
        SnackbarRepo.ShowMessagesResponse(res.Messages);
        if (!res.Success())
            return;

        Organization.Offices ??= [];
        Organization.Offices.Add(new()
        {
            Address = addingAddress!,
            Name = addingName!,
            ParentId = SelectedRubric!.Id,
            OrganizationId = Organization.Id,
            Contacts = addingContacts,
            Id = res.Response,
        });

        ToggleMode();
    }

    /// <inheritdoc/>
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await UpdateCacheRubrics();
    }

    string? _last_request;
    async Task UpdateCacheRubrics()
    {
        Organization.Offices ??= [];
        int[] added_rubrics = [..Organization
            .Offices
            .Where(x => !RubriciesCached.ContainsKey(x.ParentId))
            .Select(x => x.ParentId).Distinct()];

        if (added_rubrics.Length != 0)
        {
            string _curr_request = string.Join(",", added_rubrics);
            if (_curr_request == _last_request)
                return;
            _last_request = _curr_request;

            await SetBusy();

            foreach (int i in added_rubrics)
            {
                TResponseModel<List<RubricIssueHelpdeskModelDB>> res = await HelpdeskRepo.RubricRead(i);
                if (res.Success() && res.Response is not null)
                    RubriciesCached.Add(i, res.Response);

                if (res.Messages.Any(x => x.TypeMessage > ResultTypesEnum.Info))
                    SnackbarRepo.ShowMessagesResponse(res.Messages);
            }
            await SetBusy(false);
        }
    }

    string? GetCity(OfficeOrganizationModelDB ad)
    {
        if (!RubriciesCached.TryGetValue(ad.ParentId, out List<RubricIssueHelpdeskModelDB>? value))
            return null;

        return value.LastOrDefault()?.Name;
    }

    void RubricSelectAction(UniversalBaseModel? selectedRubric)
    {
        SelectedRubric = selectedRubric;
        StateHasChanged();
    }

    void ToggleMode()
    {
        _expanded = !_expanded;
        addingAddress = null;
        addingContacts = null;
        addingName = null;
    }


}