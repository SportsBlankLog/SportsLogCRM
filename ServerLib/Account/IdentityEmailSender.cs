using IdentityLib;
using Microsoft.AspNetCore.Identity;
using SharedLib;

namespace ServerLib;

/// <summary>
/// �������������� ASP.NET Core Identity (�� ������������� ��� ������������� � �������� ���������� ����������� ����� ������ ����������).
/// �������� ����������� ����� � �������������� � ������� ������.
/// This API supports the ASP.NET Core Identity infrastructure and is not intended to be used as a general purpose email abstraction. It should be implemented by the application so the Identity infrastructure can send confirmation and password reset emails.
/// </summary>
public sealed class IdentityEmailSender(IMailProviderService emailSender) : IEmailSender<ApplicationUser>
{
    /// <inheritdoc/>
    public Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink) =>
        emailSender.SendEmailAsync(email, "����������� ��� ����� ����������� �����", $"����������, ����������� ���� ������� <a href='{confirmationLink}'>������� �� ������</a>.");
    /// <inheritdoc/>

    public Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink) =>
        emailSender.SendEmailAsync(email, "����� ������", $"��� ������ ������ - <a href='{resetLink}'>�������� �� ������</a>.");
    /// <inheritdoc/>

    public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode) =>
        emailSender.SendEmailAsync(email, "����� ������", $"����������, �������� ������, ��������� ��������� ���: {resetCode}");
}