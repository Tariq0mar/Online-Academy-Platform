namespace Online_Academy_Platform.Application.Interfaces.External;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}