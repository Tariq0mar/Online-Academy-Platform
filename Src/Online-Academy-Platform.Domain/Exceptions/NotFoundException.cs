namespace Online_Academy_Platform.Domain.Exceptions;

public class NotFoundException : AppException
{
    public NotFoundException(string message) : base(message) { }
}