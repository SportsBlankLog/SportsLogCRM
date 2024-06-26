////////////////////////////////////////////////
// � https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SharedLib;

/// <summary>
/// �������� �������� � ���� ����� � �������� AuthenticationStateProviders ������� � �������, 
/// ����� ������������ ������� �������������� ���������� � ��������� �������� ����������� ������������.
/// </summary>
public class UserInfoMainModel
{
    /// <inheritdoc/>
    public static UserInfoMainModel Build(string userId, string? email, string[]? roles = null)
        => new() { UserId = userId, Email = email, Roles = roles };

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
    /// ���� ������������ � ���� ����� ������
    /// </summary>
    public string RolesAsString(string separator) => Roles is null || Roles.Length == 0 ? string.Empty : $"{string.Join(separator, Roles.Select(i => $"[{i}]"))}{separator}".Trim();
}