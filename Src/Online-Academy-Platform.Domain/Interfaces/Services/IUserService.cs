using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IUserService : ISearchableService<User, UserQuery>
{
    Task<User?> LoginAsync(string email, string password);

    Task<User> RegisterAsync(User user);

    Task LogoutAsync(int userId);

    Task<User?> GetByEmailAsync(string email);

    Task ChangePasswordAsync(int userId, string currentPassword, string newPassword);

    Task ActivateAsync(int userId);

    Task DeactivateAsync(int userId);

    Task<bool> EmailExistsAsync(string email);
}
