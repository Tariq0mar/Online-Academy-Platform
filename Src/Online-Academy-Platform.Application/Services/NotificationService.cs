using AutoMapper;
using Online_Academy_Platform.Application.DTOs.Notifications.Requests;
using Online_Academy_Platform.Application.DTOs.Notifications.Responses;
using Online_Academy_Platform.Application.Exceptions;
using Online_Academy_Platform.Application.Interfaces.Services;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;

namespace Online_Academy_Platform.Application.Services;

public class NotificationService(
    INotificationRepository repository,
    IUserRepository userRepository,
    IMapper mapper)
    : INotificationService
{
    public async Task<NotificationResponse> SendAsync(SendNotificationRequest request)
    {
        if (!await userRepository.ExistsAsync(request.UserId))
            throw new NotFoundException(nameof(User), request.UserId);

        var entity = mapper.Map<Notification>(request);
        entity.CreatedAt = DateTime.UtcNow;
        entity.IsRead = false;

        var created = await repository.AddAsync(entity);
        return mapper.Map<NotificationResponse>(created);
    }

    public async Task<IEnumerable<NotificationResponse>> SendBulkAsync(SendBulkNotificationRequest request)
    {
        var results = new List<NotificationResponse>();

        foreach (var userId in request.UserIds)
        {
            if (!await userRepository.ExistsAsync(userId))
                continue;

            var sendRequest = new SendNotificationRequest(userId, request.Title, request.Message);

            var response = await SendAsync(sendRequest);
            results.Add(response);
        }

        return results;
    }

    public async Task MarkAsReadAsync(int notificationId)
    {
        var entity = await repository.GetByIdAsync(notificationId);
        if (entity is null)
            throw new NotFoundException(nameof(Notification), notificationId);

        await repository.MarkAsReadAsync(notificationId);
    }

    public async Task MarkAllAsReadAsync(int userId)
    {
        if (!await userRepository.ExistsAsync(userId))
            throw new NotFoundException(nameof(User), userId);

        await repository.MarkAllAsReadByUserIdAsync(userId);
    }

    public async Task<int> GetUnreadCountAsync(int userId)
    {
        if (!await userRepository.ExistsAsync(userId))
            throw new NotFoundException(nameof(User), userId);

        return await repository.CountUnreadByUserIdAsync(userId);
    }

    public async Task<IEnumerable<NotificationResponse>> GetByUserIdAsync(int userId)
    {
        if (!await userRepository.ExistsAsync(userId))
            throw new NotFoundException(nameof(User), userId);

        var notifications = await repository.GetUnreadByUserIdAsync(userId);
        return mapper.Map<IEnumerable<NotificationResponse>>(notifications);
    }

    public async Task DeleteOldAsync(int daysOld)
    {
        var all = await repository.GetAllAsync();
        var cutoff = DateTime.UtcNow.AddDays(-daysOld);

        foreach (var notification in all.Where(n => n.CreatedAt < cutoff))
        {
            await repository.DeleteAsync(notification.Id);
        }
    }

    public async Task<NotificationResponse> GetByIdAsync(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity is null)
            throw new NotFoundException(nameof(Notification), id);

        return mapper.Map<NotificationResponse>(entity);
    }

    public async Task<IEnumerable<NotificationResponse>> GetAllAsync()
    {
        var entities = await repository.GetAllAsync();
        return mapper.Map<IEnumerable<NotificationResponse>>(entities);
    }

    public async Task DeleteAsync(int id)
    {
        if (!await repository.ExistsAsync(id))
            throw new NotFoundException(nameof(Notification), id);

        await repository.DeleteAsync(id);
    }
}