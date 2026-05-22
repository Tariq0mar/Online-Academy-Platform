namespace Online_Academy_Platform.Application.DTOs.Notifications.Requests;

public class SendBulkNotificationRequest
{
    public IEnumerable<int> UserIds { get; set; } = new List<int>();

    public required string Title { get; set; }

    public required string Message { get; set; }
}