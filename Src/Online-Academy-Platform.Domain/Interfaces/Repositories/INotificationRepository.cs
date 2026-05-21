using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface INotificationRepository : IQueryableRepository<Notification, NotificationQuery>
{
    Task<int> CountUnreadByUserIdAsync(int userId);

    Task<IEnumerable<Notification>> GetUnreadByUserIdAsync(int userId);

    Task MarkAsReadAsync(int notificationId);

    Task MarkAllAsReadByUserIdAsync(int userId);
}
