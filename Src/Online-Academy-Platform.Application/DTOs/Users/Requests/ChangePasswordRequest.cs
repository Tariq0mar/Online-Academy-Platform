namespace Online_Academy_Platform.Application.DTOs.Users.Requests;

public sealed record ChangePasswordRequest(int UserId, string CurrentPassword, string NewPassword);