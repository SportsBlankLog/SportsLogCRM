﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using System.ComponentModel;

namespace SharedLib;

/// <summary>
/// Признак актуальности
/// </summary>
/// <remarks>
/// «Признак актуальности», отражает актуальность конкретного наименования данного адресного объекта и выделяет это наименование среди остальных его наименований,
/// а также актуальность его административного подчинения, его существования.
/// </remarks>
public enum SignOfRelevanciesEnum
{
    /// <summary>
    /// “00” – актуальный объект
    /// </summary>
    /// <remarks>
    /// (его наименование, подчиненность соответствуют состоянию на данный момент адресного пространства)
    /// </remarks>
    [Description("актуальный")]
    Actual,

    /// <summary>
    /// “01”-“50” – объект был переименован, в данной записи приведено одно из прежних его наименований
    /// </summary>
    /// <remarks>
    /// (актуальный адресный объект присутствует в базе данных с тем же кодом, но с признаком актуальности “00”)
    /// </remarks>
    [Description("переименован")]
    Renamed,

    /// <summary>
    /// “51” –  объект был переподчинен или влился в состав другого объекта
    /// </summary>
    /// <remarks>
    /// (актуальный адресный объект определяется по базе Altnames.dbf)
    /// </remarks>
    [Description("переподчинен/влился")]
    WasReassigned,

    /// <summary>
    /// “52”-“98” – резервные значения признака актуальности
    /// </summary>
    [Description("резервный")]
    Reserve,

    /// <summary>
    /// ”99” – адресный объект не существует, т.е. нет соответствующего ему актуального адресного объекта
    /// </summary>
    [Description("не существует")]
    NotExist,
}
