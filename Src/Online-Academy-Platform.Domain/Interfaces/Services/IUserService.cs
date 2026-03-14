using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface IUserService
{
    // Authentication
    Task<User?> LoginAsync(string email, string password);

    Task<User> RegisterAsync(User user);

    Task LogoutAsync(int userId);

    // User retrieval
    Task<User?> GetUserByIdAsync(int id);

    Task<User?> GetUserByEmailAsync(string email);

    Task<IEnumerable<User>> GetAllUsersAsync();

    Task<IEnumerable<User>> QueryUsersAsync(UserQuery query);

    // User management
    Task UpdateUserAsync(User user);

    Task DeleteUserAsync(int id);

    Task ActivateUserAsync(int id);

    Task DeactivateUserAsync(int id);

    Task<bool> EmailExistsAsync(string email);
}