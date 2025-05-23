////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorLib.Components.Kladr.main;

/// <summary>
/// LinksKladrComponent
/// </summary>
public partial class LinksKladrComponent : KladrNavBaseNodeComponent
{
    [Inject]
    IJSRuntime JSRepo { get; set; } = default!;


    /// <inheritdoc/>
    [Parameter]
    public bool HideMapLink { get; set; }

    /// <summary>
    /// Почтовый индекс
    /// </summary>
    [Parameter, EditorRequired]
    public string? PostIndex { get; set; }

    /// <inheritdoc/>
    [Parameter, EditorRequired]
    public required QueryNavKladrComponent Owner { get; set; }

    /// <inheritdoc/>
    [CascadingParameter, EditorRequired]
    public required IReadOnlyCollection<string>? SelectedFieldsView { get; set; }


    async Task GoToMap()
        => await JSRepo.InvokeVoidAsync("open", $"https://yandex.ru/maps?text={string.Join(", ", GetNamesScheme(Owner).Select(x => x.ToString()))}", "_blank");
}