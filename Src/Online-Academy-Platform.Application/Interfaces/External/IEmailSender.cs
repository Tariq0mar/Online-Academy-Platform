namespace Online_Academy_Platform.Application.Interfaces.External;

public interface IEmailSender
{
    Task SendEmailAsync(string recipient, string subject, string body);
}