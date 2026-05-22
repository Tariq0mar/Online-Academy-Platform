using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Users.Responses;

public sealed record UserResponse(
    int Id,
    string Name,
    string Email,
    string Phone,
    string? ProfilePicture,
    bool Active,
    UserRole Role,
    DateTime CreatedAt);