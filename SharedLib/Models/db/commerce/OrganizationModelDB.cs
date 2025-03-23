﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// Организация
/// </summary>
public class OrganizationModelDB : OrganizationLegalModel
{
    /// <summary>
    /// Дата последнего обновления
    /// </summary>
    public DateTime LastAtUpdatedUTC { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAtUTC { get; set; }

    /// <summary>
    /// НОВОЕ Название (запрос изменений)
    /// </summary>
    public string? NewName { get; set; }
    /// <summary>
    /// НОВЫЙ Юридический адрес (запрос изменений)
    /// </summary>
    public string? NewLegalAddress { get; set; }
    /// <summary>
    /// НОВЫЙ ИНН (запрос изменений)
    /// </summary>
    public string? NewINN { get; set; }
    /// <summary>
    /// НОВЫЙ КПП (запрос изменений)
    /// </summary>
    public string? NewKPP { get; set; }
    /// <summary>
    /// НОВЫЙ ОГРН (запрос изменений)
    /// </summary>
    public string? NewOGRN { get; set; }

    /// <summary>
    /// Банковские реквизиты
    /// </summary>
    public List<BankDetailsModelDB>? BanksDetails { get; set; }

    /// <summary>
    /// Находится ли объект в режиме запроса изменений реквизитов
    /// </summary>
    public bool HasRequestToChange
    {
        get
        {
            return
                !string.IsNullOrWhiteSpace(NewName) ||
                !string.IsNullOrWhiteSpace(NewLegalAddress) ||
                !string.IsNullOrWhiteSpace(NewINN) ||
                !string.IsNullOrWhiteSpace(NewKPP);
        }
    }

    /// <summary>
    /// Users
    /// </summary>
    public List<UserOrganizationModelDB>? Users { get; set; }

    /// <summary>
    /// Подрядчики (организации)
    /// </summary>
    public List<OrganizationContractorModel>? Contractors { get; set; }

    /// <summary>
    /// Addresses
    /// </summary>
    public List<OfficeOrganizationModelDB>? Offices { get; set; }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj is OrganizationModelDB org_db)
            return
                org_db.IsDisabled == IsDisabled &&
                org_db.OGRN == OGRN &&
                org_db.Email == Email &&
                org_db.INN == INN &&
                org_db.Name == Name &&
                org_db.KPP == KPP &&
                org_db.Id == Id &&
                org_db.Phone == Phone &&
                org_db.LegalAddress == LegalAddress;

        return base.Equals(obj);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
        => $"{Id}{KPP}{Name}{INN}{Email}{OGRN}{IsDisabled}{LegalAddress}{Phone}".GetHashCode();
}