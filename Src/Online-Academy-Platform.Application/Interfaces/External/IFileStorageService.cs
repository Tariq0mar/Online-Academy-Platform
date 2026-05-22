namespace Online_Academy_Platform.Application.Interfaces.External;

public interface IFileStorageService
{
    Task<string> UploadFileAsync(string pathOrContent, string containerName);
}