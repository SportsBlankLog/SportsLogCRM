﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using BlazorLib.Components.Shared.Constructor;
using Microsoft.AspNetCore.Components;
using BlazorLib;
using MudBlazor;
using SharedLib;

namespace BlazorLib.Components.Shared.Constructor;

/// <summary>
/// Client table row edit dialog
/// </summary>
public partial class ClientTableRowEditDialogComponent : BlazorBusyComponentBaseModel
{
    [CascadingParameter]
    IMudDialogInstance MudDialog { get; set; } = default!;

    /// <inheritdoc/>
    [Parameter, EditorRequired]
    public uint RowNum { get; set; }

    /// <inheritdoc/>
    [Parameter]
    public SessionOfDocumentDataModelDB SessionDocument { get; set; } = default!;

    /// <inheritdoc/>
    [Parameter]
    public TabOfDocumentSchemeConstructorModelDB DocumentPage { get; set; } = default!;

    /// <inheritdoc/>
    [Parameter, EditorRequired]
    public FormToTabJoinConstructorModelDB PageJoinForm { get; set; } = default!;

    /// <inheritdoc/>
    [Parameter, EditorRequired]
    public required ConstructorMainManageComponent ParentFormsPage { get; set; }


    /// <inheritdoc/>
    protected List<ValueDataForSessionOfDocumentModelDB> RowValuesSet = [];

    /// <inheritdoc/>
    protected IEnumerable<EntryAltDescriptionModel> Entries = [];

    /// <inheritdoc/>
    protected void Close() => InvokeAsync(async () =>
    {
        while (IsBusyProgress)
            await Task.Delay(100);

        MudDialog.Close(DialogResult.Ok(RowValuesSet));
    });
}