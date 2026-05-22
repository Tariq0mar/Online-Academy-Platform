namespace Online_Academy_Platform.Application.Interfaces.External;

public interface IPasswordHasher
{
    string Hash(string plainText);

    bool Verify(string plainText, string hashedValue);
}