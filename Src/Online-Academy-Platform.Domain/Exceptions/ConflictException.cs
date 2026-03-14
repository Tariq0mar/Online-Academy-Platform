namespace Online_Academy_Platform.Domain.Exceptions;

public class ConflictException : AppException
{
    public ConflictException(string message) : base(message) { }
}