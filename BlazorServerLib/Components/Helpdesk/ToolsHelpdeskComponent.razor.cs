﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using SharedLib;

namespace BlazorWebLib.Components.Helpdesk;

/// <summary>
/// ParametersHelpdeskComponent
/// </summary>
public partial class ToolsHelpdeskComponent
{
    static readonly EntryAltModel[] showMarkersRoles = [new() { Id = GlobalStaticConstantsRoles.Roles.CommerceClient, Name = "Покупатель" }];
}