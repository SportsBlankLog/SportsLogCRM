﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using BlazorLib;
using BlazorLib.Components;
using BlazorWebLib.Components.Constructor.Pages;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using SharedLib;

namespace BlazorWebLib.Components.Constructor.Shared.FieldsRowsEditUI;

/// <summary>
/// Field directory form row edit
/// </summary>
public partial class FieldDirectoryFormRowEditComponent : BlazorBusyComponentBaseModel, IDomBaseComponent
{
    /// <inheritdoc/>
    [Inject]
    protected IConstructorTransmission ConstructorRepo { get; set; } = default!;


    /// <inheritdoc/>
    [CascadingParameter, EditorRequired]
    public Action<FieldFormAkaDirectoryConstructorModelDB> StateHasChangedHandler { get; set; } = default!;

    /// <inheritdoc/>
    [Parameter, EditorRequired]
    public FieldFormAkaDirectoryConstructorModelDB Field { get; set; } = default!;

    /// <summary>
    /// Форма
    /// </summary>
    [CascadingParameter, EditorRequired]
    public required FormConstructorModelDB Form { get; set; }

    /// <summary>
    /// Родительская страница форм
    /// </summary>
    [CascadingParameter, EditorRequired]
    public required ConstructorPage ParentFormsPage { get; set; }


    /// <inheritdoc/>
    protected IEnumerable<EntryModel>? Entries;

    /// <inheritdoc/>
    public string DomID => $"{Field.GetType().FullName}_{Field.Id}";


    /// <inheritdoc/>
    public int SelectedDirectoryField
    {
        get => Field.DirectoryId;
        private set
        {
            Field.DirectoryId = value;
            if (Field.Directory is not null)
                Field.Directory.Id = value;
            StateHasChangedHandler(Field);
        }
    }

    /// <inheritdoc/>
    public bool IsMultiDirectoryField
    {
        get => Field.IsMultiSelect;
        private set
        {
            Field.IsMultiSelect = value;
            StateHasChangedHandler(Field);
        }
    }

    /// <inheritdoc/>
    public void Update(FieldFormAkaDirectoryConstructorModelDB field)
    {
        Field.Update(field);
        StateHasChanged();
    }

    /// <inheritdoc/>
    protected override async Task OnInitializedAsync()
    {
        await SetBusyAsync();
        TResponseModel<EntryModel[]> rest = await ConstructorRepo.GetDirectoriesAsync(new() { ProjectId = Form.ProjectId });
        Entries = rest.Response ?? throw new Exception();
        await SetBusyAsync(false);
    }
}