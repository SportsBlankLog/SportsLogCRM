////////////////////////////////////////////////
// � https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// �������� �������� � ���� ����� � �������� AuthenticationStateProviders ������� � �������, 
/// ����� ������������ ������� �������������� ���������� � ��������� �������� ����������� ������������.
/// </summary>
public record UserInfoMainModel
{
    /// <summary>
    /// FirstName
    /// </summary>
    public string? GivenName { get; set; }

    /// <summary>
    /// LastName
    /// </summary>
    public string? Surname { get; set; }

    /// <inheritdoc/>
    public required string UserId { get; init; }

    /// <inheritdoc/>
    public string? UserName { get; init; }

    /// <inheritdoc/>
    public string? Email { get; init; }

    /// <summary>
    /// ������������ �������� Telegram � ������� ������
    /// </summary>
    public long? TelegramId { get; init; }

    /// <summary>
    /// ���� ������������
    /// </summary>
    public List<string>? Roles { get; set; }

    /// <summary>
    /// Claims
    /// </summary>
    public EntryAltModel[]? Claims { get; init; }

    /// <summary>
    /// ���� ������������ � ���� ����� ������
    /// </summary>
    public string RolesAsString(string separator) => Roles is null || Roles.Count == 0 ? string.Empty : $"{string.Join(separator, Roles.Select(i => $"[{i}]"))}{separator}".Trim();

    /// <summary>
    /// Claims
    /// </summary>
    public string ClaimsAsString(string separator) => Claims is null || Claims.Length == 0 ? string.Empty : $"{string.Join(separator, Claims.Select(y => $"[{y.Id}: {y.Name}]"))}{separator}".Trim();

    /// <summary>
    /// ������� ���� admin
    /// </summary>
    [System.Text.Json.Serialization.JsonIgnore]
    [Newtonsoft.Json.JsonIgnore]
    public bool IsAdmin => Roles?.Any(x => x.Equals(GlobalStaticConstants.Roles.Admin, StringComparison.OrdinalIgnoreCase)) == true;
}