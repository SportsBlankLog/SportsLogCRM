﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @FakeGov 
////////////////////////////////////////////////

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SharedLib;

/// <summary>
/// Сессия опроса/анкеты
/// </summary>
[Index(nameof(AuthorUser)), Index(nameof(SessionToken)), Index(nameof(SessionStatus)), Index(nameof(CreatedAt)), Index(nameof(LastDocumentUpdateActivity)), Index(nameof(DeadlineDate))]
[Index(nameof(OwnerId), nameof(ProjectId), nameof(NormalizedUpperName), IsUnique = true)]
public class SessionOfDocumentDataModelDB : EntryDescriptionOwnedModel, ICloneable
{
    /// <summary>
    /// Нормализованное имя: UPPERCASE
    /// </summary>
    [Required(AllowEmptyStrings = false, ErrorMessage = "Поле наименования обязательно для заполнения")]
    public required string NormalizedUpperName { get; set; }

    /// <summary>
    /// Опрос/анкета
    /// </summary>
    public DocumentSchemeConstructorModelDB? Owner { get; set; }

    /// <summary>
    /// Project
    /// </summary>
    public ProjectModelDb? Project { get; set; }

    /// <summary>
    /// Project
    /// </summary>
    public required int ProjectId { get; set; }

    /// <summary>
    /// Автор/создатель ссылки
    /// </summary>
    public required string AuthorUser { get; set; }

    /// <summary>
    /// Адреса для отправки уведомлений
    /// </summary>
    public string? EmailsNotifications { get; set; }

    /// <summary>
    /// Клиенты, вносившие данные в контексте сессии
    /// </summary>
    public string? Editors { get; set; }

    /// <summary>
    /// токен доступа к сессии
    /// </summary>
    public string? SessionToken { get; set; }

    /// <summary>
    /// Статус сессии
    /// </summary>
    public SessionsStatusesEnum SessionStatus { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Последнее обновление данных опроса/анкеты (последняя активность по вводу значений)
    /// </summary>
    public DateTime? LastDocumentUpdateActivity { get; set; }

    /// <summary>
    /// Первой вкладкой будет специальная для отображения описания.
    /// Что-то вроде вступительной страницы с общей информацией
    /// </summary>
    public bool ShowDescriptionAsStartPage { get; set; }

    /// <summary>
    /// Дата окончания актуальности сессии/токена
    /// </summary>
    public DateTime? DeadlineDate { get; set; }

    /// <summary>
    /// Значения полей форм
    /// </summary>
    public List<ValueDataForSessionOfDocumentModelDB>? DataSessionValues { get; set; }

    /// <summary>
    /// Проверка возможности внесения данных в сессию
    /// </summary>
    public bool CanMakeData(UserInfoModel? user = null)
    {
        if (user is null)
            return SessionStatus == SessionsStatusesEnum.InProgress && Guid.TryParse(SessionToken, out Guid _guid) && _guid != Guid.Empty && (DeadlineDate.HasValue && DeadlineDate.Value >= DateTime.UtcNow);

        if (Project is null)
            return user.Roles?.Any(x => x.Equals(GlobalStaticConstantsRoles.Roles.Admin, StringComparison.OrdinalIgnoreCase)) == true;

        return user.UserId.Equals(Project.OwnerUserId) || user.Roles?.Any(x => x.Equals(GlobalStaticConstantsRoles.Roles.Admin, StringComparison.OrdinalIgnoreCase)) == true;
    }

    /// <summary>
    /// Введённые значения в табличную форму
    /// </summary>
    public IQueryable<ValueDataForSessionOfDocumentModelDB>? QueryCurrentTablePageFormValues(int page_join_id)
    {
        return DataSessionValues?
               .Where(x => x.RowNum > 0 && x.JoinFormToTabId == page_join_id)
               .AsQueryable();
    }

    /// <inheritdoc/>
    public IGrouping<uint, ValueDataForSessionOfDocumentModelDB>[]? RowsData(int page_join_id)
    {
        return QueryCurrentTablePageFormValues(page_join_id)?
               .GroupBy(x => x.RowNum)
               .OrderBy(x => x.Key)
               .ToArray();
    }

    /// <summary>
    /// Перезагрузить объект
    /// </summary>
    public void Reload(SessionOfDocumentDataModelDB other)
    {
        ProjectId = other.ProjectId;
        Id = other.Id;
        AuthorUser = other.AuthorUser;
        Editors = other.Editors;
        OwnerId = other.OwnerId;
        DeadlineDate = other.DeadlineDate;
        ShowDescriptionAsStartPage = other.ShowDescriptionAsStartPage;
        LastDocumentUpdateActivity = other.LastDocumentUpdateActivity;
        CreatedAt = other.CreatedAt;
        SessionStatus = other.SessionStatus;
        SessionToken = other.SessionToken;
        EmailsNotifications = other.EmailsNotifications;
        Name = other.Name;
        NormalizedUpperName = other.NormalizedUpperName;
        Description = other.Description;
        if (other.DataSessionValues is not null)
        {
            DataSessionValues ??= [];

            int i = DataSessionValues.FindIndex(x => !other.DataSessionValues.Any(y => y.Id == x.Id));
            while (i >= 0)
            {
                DataSessionValues.RemoveAt(i);
                i = DataSessionValues.FindIndex(x => !other.DataSessionValues.Any(y => y.Id == x.Id));
            }

            ValueDataForSessionOfDocumentModelDB? _s;
            foreach (ValueDataForSessionOfDocumentModelDB sv in DataSessionValues)
            {
                _s = other.DataSessionValues.FirstOrDefault(x => x.Id == sv.Id);
                if (_s is not null)
                    sv.Value = _s.Value;
            }

            ValueDataForSessionOfDocumentModelDB[] _values = other.DataSessionValues.Where(x => !DataSessionValues.Any(y => y.Id == x.Id)).ToArray();
            if (_values.Length != 0)
                DataSessionValues.AddRange(_values);
        }

        if (other.Owner is not null && Owner is not null)
            Owner.Reload(other.Owner);
    }

    /// <inheritdoc/>
    public object Clone()
    {
        return new SessionOfDocumentDataModelDB()
        {
            AuthorUser = AuthorUser,
            Name = Name,
            NormalizedUpperName = NormalizedUpperName,
            ProjectId = ProjectId,
            CreatedAt = CreatedAt,
            DataSessionValues = DataSessionValues,
            DeadlineDate = DeadlineDate,
            Description = Description,
            Editors = Editors,
            EmailsNotifications = EmailsNotifications,
            Id = Id,
            LastDocumentUpdateActivity = LastDocumentUpdateActivity,
            Owner = Owner,
            OwnerId = OwnerId,
            Project = Project,
            SessionStatus = SessionStatus,
            SessionToken = SessionToken,
            ShowDescriptionAsStartPage = ShowDescriptionAsStartPage,
        };
    }
}