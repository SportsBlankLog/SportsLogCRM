﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using MudBlazor;
using SharedLib;

namespace BlazorLib.Components.Constructor;

/// <summary>
/// DocumentScheme client view
/// </summary>
public partial class DocumentClientViewComponent : ComponentBase
{
    [Inject]
    ISnackbar SnackbarRepo { get; set; } = default!;


    /// <summary>
    /// Session questionnaire
    /// </summary>
    [CascadingParameter, EditorRequired]
    public required SessionOfDocumentDataModelDB SessionOfDocumentData { get; set; }

    /// <inheritdoc/>
    [CascadingParameter, EditorRequired]
    public bool InUse { get; set; } = default!;


    /// <summary>
    /// Информация
    /// </summary>
    protected MarkupString Information => (MarkupString)(!string.IsNullOrWhiteSpace(SessionOfDocumentData.Description) ? SessionOfDocumentData.Description : SessionOfDocumentData.Owner!.Description ?? "");

    /// <summary>
    /// В зависимости режима (InUse) стили, которые добавятся к кнопке добавления: Если документ используется для реального заполнения, то кнопка скрывается.
    /// </summary>
    protected string AddIconStyleInUse => InUse ? "display:none;" : "";
}