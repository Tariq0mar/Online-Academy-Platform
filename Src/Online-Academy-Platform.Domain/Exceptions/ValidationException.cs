namespace Online_Academy_Platform.Domain.Exceptions;

public class ValidationException : AppException
{
    public ValidationException(string message) : base(message) { }
}