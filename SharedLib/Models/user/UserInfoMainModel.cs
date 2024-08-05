////////////////////////////////////////////////
// � https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// �������� �������� � ���� ����� � �������� AuthenticationStateProviders ������� � �������, 
/// ����� ������������ ������� �������������� ���������� � ��������� �������� ����������� ������������.
/// </summary>
public class UserInfoMainModel
{
    /// <inheritdoc/>
    public required string UserId { get; set; }

    /// <inheritdoc/>
    public string? UserName { get; set; }

    /// <inheritdoc/>
    public string? Email { get; set; }

    /// <summary>
    /// ���� ������������
    /// </summary>
    public string[]? Roles { get; set; }

    /// <summary>
    /// Claims
    /// </summary>
    public EntryAltModel[]? Claims { get; set; }

    /// <summary>
    /// ���� ������������ � ���� ����� ������
    /// </summary>
    public string RolesAsString(string separator) => Roles is null || Roles.Length == 0 ? string.Empty : $"{string.Join(separator, Roles.Select(i => $"[{i}]"))}{separator}".Trim();

    /// <summary>
    /// Claims
    /// </summary>
    public string ClaimsAsString(string separator) => Claims is null || Claims.Length == 0 ? string.Empty : $"{string.Join(separator, Claims.Select(y => $"[{y.Id}: {y.Name}]"))}{separator}".Trim();

    /// <inheritdoc/>
    public static UserInfoMainModel Build(string userId, string? userName, string? email, string[]? roles = null)
        => new() { UserId = userId, Email = email, Roles = roles, UserName = userName };
}