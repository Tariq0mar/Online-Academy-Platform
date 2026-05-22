using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Application.DTOs.Users.Requests;

public sealed record UpdateUserRequest(
    string Name,
    string Phone,
    string? ProfilePicture,
    bool Active,
    UserRole Role);