using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Users.Requests;
using Online_Academy_Platform.Application.DTOs.Users.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class UserService(
    IUserRepository repository,
    IMapper mapper)
    : IUserService
{
    public async Task<UserResponse> RegisterAsync(RegisterUserRequest request)
    {
        if (await repository.ExistsByEmailAsync(request.Email))
            throw new ValidationException($"Email '{request.Email}' is already registered.");

        var entity = mapper.Map<User>(request);
        entity.PasswordHash = HashPassword(request.Password);
        entity.CreatedAt = DateTime.UtcNow;
        entity.Active = true;

        var created = await repository.AddAsync(entity);
        return mapper.Map<UserResponse>(created);
    }

    public async Task<UserResponse> LoginAsync(LoginRequest request)
    {
        var entity = await repository.GetByEmailAsync(request.Email);
        if (entity is null)
            throw new ValidationException("Invalid email or password.");

        if (!entity.Active)
            throw new ValidationException("This account has been deactivated.");

        if (!VerifyPassword(request.Password, entity.PasswordHash))
            throw new ValidationException("Invalid email or password.");

        return mapper.Map<UserResponse>(entity);
    }

    public async Task LogoutAsync(int userId)
    {
        if (!await repository.ExistsAsync(userId))
            throw new NotFoundException(nameof(User), userId);

        // Placeholder: stateless logout; invalidate token at API gateway/frontend.
        await Task.CompletedTask;
    }

    public async Task<UserResponse> GetByEmailAsync(string email)
    {
        var entity = await repository.GetByEmailAsync(email);
        if (entity is null)
            throw new NotFoundException($"User with email '{email}' was not found.");

        return mapper.Map<UserResponse>(entity);
    }

    public async Task<bool> EmailExistsAsync(string email) =>
        await repository.ExistsByEmailAsync(email);

    public async Task ChangePasswordAsync(int userId, ChangePasswordRequest request)
    {
        if (userId != request.UserId)
            throw new ValidationException("User ID mismatch.");

        var entity = await repository.GetByIdAsync(userId);
        if (entity is null)
            throw new NotFoundException(nameof(User), userId);

        if (!VerifyPassword(request.CurrentPassword, entity.PasswordHash))
            throw new ValidationException("Current password is incorrect.");

        entity.PasswordHash = HashPassword(request.NewPassword);
        await repository.UpdateAsync(entity);
    }

    public async Task ActivateAsync(int userId)
    {
        var entity = await repository.GetByIdAsync(userId);
        if (entity is null)
            throw new NotFoundException(nameof(User), userId);

        entity.Active = true;
        await repository.UpdateAsync(entity);
    }

    public async Task DeactivateAsync(int userId)
    {
        var entity = await repository.GetByIdAsync(userId);
        if (entity is null)
            throw new NotFoundException(nameof(User), userId);

        entity.Active = false;
        await repository.UpdateAsync(entity);
    }

    public async Task<IEnumerable<UserResponse>> GetByRoleAsync(string role)
    {
        if (!Enum.TryParse<UserRole>(role, ignoreCase: true, out var parsedRole))
            throw new ValidationException($"Invalid role: '{role}'.");

        var users = await repository.GetByRoleAsync(parsedRole);
        return mapper.Map<IEnumerable<UserResponse>>(users);
    }

    // ── helpers ──
    private static string HashPassword(string password)
    {
        var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        return Convert.ToHexString(bytes);
    }

    private static bool VerifyPassword(string password, string hash)
    {
        var candidateHash = HashPassword(password);
        return string.Equals(candidateHash, hash, StringComparison.OrdinalIgnoreCase);
    }

    // ── CRUD ──
    public async Task<UserResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(User), id);

        return mapper.Map<UserResponse>(entity);
    }

    public async Task<IEnumerable<UserResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<UserResponse>>(entities);
    }

    public async Task<UserResponse> UpdateAsync(int id, UpdateUserRequest request)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(User), id);

        // UpdateUserRequest does not contain Email; it remains unchanged.
        mapper.Map(request, entity);
        await repository.UpdateAsync(entity);

        return mapper.Map<UserResponse>(entity);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(User), id);

        await repository.DeleteAsync(id);
    }
}