using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface INotificationService : ISearchableService<Notification, NotificationQuery>
{
    Task<Notification> SendAsync(int userId, string title, string message);

    Task MarkAsReadAsync(int notificationId);

    Task MarkAllAsReadAsync(int userId);

    Task<int> GetUnreadCountAsync(int userId);
}
