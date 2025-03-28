﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using BlazorWebLib.Components.Constructor.Shared.Manufacture;
using Microsoft.AspNetCore.Components;
using BlazorLib;
using SharedLib;

namespace BlazorWebLib.Components.Constructor.Pages;

/// <inheritdoc/>
public partial class ConstructorPage : BlazorBusyComponentBaseAuthModel
{
    [Inject]
    IConstructorTransmission ConstructorRepo { get; set; } = default!;


    ManufactureComponent? manufacture_ref = default!;


    /// <inheritdoc/>
    public List<SystemNameEntryModel>? SystemNamesManufacture;

    /// <inheritdoc/>
    public MainProjectViewModel? MainProject { get; private set; }

    /// <summary>
    /// Проверка разрешения редактировать проект
    /// </summary>
    public bool CanEditProject { get; private set; }


    /// <inheritdoc/>
    protected override async Task OnInitializedAsync()
    {
        await SetBusyAsync();
        await ReadCurrentUser();
        await ReadCurrentMainProject();
    }

    /// <summary>
    /// Прочитать данные о текущем/основном проекте
    /// </summary>
    public async Task ReadCurrentMainProject()
    {
        CanEditProject = false;
        await SetBusyAsync();

        TResponseModel<MainProjectViewModel> currentMainProject = await ConstructorRepo.GetCurrentMainProjectAsync(CurrentUserSession!.UserId);

        if (!currentMainProject.Success())
            SnackbarRepo.ShowMessagesResponse(currentMainProject.Messages);

        MainProject = currentMainProject.Response;
        CanEditProject = MainProject is not null && (!MainProject.IsDisabled || MainProject.OwnerUserId.Equals(CurrentUserSession!.UserId) || CurrentUserSession!.IsAdmin);
        IsBusyProgress = false;

    }
}