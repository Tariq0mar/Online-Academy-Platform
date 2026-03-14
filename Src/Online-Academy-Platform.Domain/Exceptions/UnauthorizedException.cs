namespace Online_Academy_Platform.Domain.Exceptions;

public class UnauthorizedException : AppException
{
    public UnauthorizedException(string message) : base(message) { }
}