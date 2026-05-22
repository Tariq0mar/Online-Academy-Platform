namespace Online_Academy_Platform.Application.Interfaces.External;

public interface INotificationSender
{
    Task PublishNotificationAsync(int userId, string title, string message);
}