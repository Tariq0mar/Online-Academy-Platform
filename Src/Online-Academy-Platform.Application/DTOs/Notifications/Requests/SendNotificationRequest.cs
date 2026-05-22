namespace Online_Academy_Platform.Application.DTOs.Notifications.Requests;

public sealed record SendNotificationRequest(int UserId, string Title, string Message);