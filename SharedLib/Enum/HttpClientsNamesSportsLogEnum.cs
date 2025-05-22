////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using System.ComponentModel;

namespace SharedLib;

/// <summary>
/// Имена HTTP клиентов для IHttpClientFactory (например: IHttpClientFactory.CreateClient(HttpClientsNamesEnum.Insight.ToString()))
/// </summary>
public enum HttpClientsNamesSportsLogEnum
{
    /// <summary>
    /// Fantasy402
    /// </summary>
    [Description("Fantasy402")]
    Fantasy402 = 10,
}