using Online_Academy_Platform.Application.DTOs.Notifications.Requests;
using Online_Academy_Platform.Application.DTOs.Notifications.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface INotificationService
{
    Task<NotificationResponse> SendAsync(SendNotificationRequest request);

    Task<IEnumerable<NotificationResponse>> SendBulkAsync(SendBulkNotificationRequest request);

    Task MarkAsReadAsync(int notificationId);

    Task MarkAllAsReadAsync(int userId);

    Task<int> GetUnreadCountAsync(int userId);

    Task<IEnumerable<NotificationResponse>> GetByUserIdAsync(int userId);

    Task DeleteOldAsync(int daysOld);

    Task<NotificationResponse> GetByIdAsync(int id);

    Task<IEnumerable<NotificationResponse>> GetAllAsync();

    Task DeleteAsync(int id);
}