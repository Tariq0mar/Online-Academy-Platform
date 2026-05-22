using Online_Academy_Platform.Application.DTOs.Users.Requests;
using Online_Academy_Platform.Application.DTOs.Users.Responses;

namespace Online_Academy_Platform.Application.Interfaces.Services;

public interface IUserService
{
    Task<UserResponse> RegisterAsync(RegisterUserRequest request);

    Task<UserResponse> LoginAsync(LoginRequest request);

    Task LogoutAsync(int userId);

    Task<UserResponse> GetByEmailAsync(string email);

    Task<bool> EmailExistsAsync(string email);

    Task ChangePasswordAsync(int userId, ChangePasswordRequest request);

    Task ActivateAsync(int userId);

    Task DeactivateAsync(int userId);

    Task<IEnumerable<UserResponse>> GetByRoleAsync(string role);

    Task<UserResponse> GetByIdAsync(int id);

    Task<IEnumerable<UserResponse>> GetAllAsync();

    Task<UserResponse> UpdateAsync(int id, UpdateUserRequest request);

    Task DeleteAsync(int id);
}