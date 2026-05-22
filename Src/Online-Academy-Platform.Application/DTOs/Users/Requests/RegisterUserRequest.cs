using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Users.Requests;

public sealed record RegisterUserRequest(
    string Name,
    string Email,
    string Password,
    string Phone,
    UserRole Role,
    string? ProfilePicture);