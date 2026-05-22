namespace Online_Academy_Platform.Application.Exceptions;

public class NotFoundException : Exception
{
    public string ResourceName { get; }
    public object? ResourceKey { get; }

    public NotFoundException(string resourceName, object? resourceKey = null)
        : base($"{resourceName} with key '{resourceKey}' was not found.")
    {
        ResourceName = resourceName;
        ResourceKey = resourceKey;
    }

    public NotFoundException(string message) : base(message)
    {
        ResourceName = string.Empty;
    }
}