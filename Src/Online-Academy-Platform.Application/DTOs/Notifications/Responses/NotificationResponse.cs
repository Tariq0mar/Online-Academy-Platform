using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Notifications.Responses;

public sealed record NotificationResponse(
    int Id,
    int UserId,
    string Title,
    string Message,
    bool IsRead,
    DateTime CreatedAt);