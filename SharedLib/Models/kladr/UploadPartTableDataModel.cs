﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// Загрузка порции данных
/// </summary>
public class UploadPartTableDataModel
{
    /// <summary>
    /// Columns
    /// </summary>
    public required List<FieldDescriptorBase> Columns { get; set; }

    /// <summary>
    /// RowsData
    /// </summary>
    public required List<object[]> RowsData { get; set; }

    /// <summary>
    /// Имя таблицы
    /// </summary>
    public required string TableName { get; set; }
}

/// <summary>
/// Настройки отображения навигационного дерева КЛАДР
/// </summary>
public class KladrMainTreeViewSetModel
{
    /// <summary>
    /// Отображаемые поля
    /// </summary>
    public IReadOnlyCollection<string>? SelectedFieldsView { get; set; }
}