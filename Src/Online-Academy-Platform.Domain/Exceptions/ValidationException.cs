namespace Online_Academy_Platform.Domain.Exceptions;

public class ValidationException : AppException
{
    public ValidationException(string message) : base(message) { }

    public ValidationException(string message, IReadOnlyDictionary<string, string[]> errors)
        : base(message)
    {
        Errors = errors;
    }

    public IReadOnlyDictionary<string, string[]>? Errors { get; }
}
