using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface INotificationService: IService<Notification>
{
    Task<Notification> QueryAsync(NotificationQuery query);
}