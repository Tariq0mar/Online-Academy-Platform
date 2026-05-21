using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class NotificationRepository(ApplicationDbContext context)
    : QueryableRepository<Notification, NotificationQuery>(context), INotificationRepository
{
    protected override IQueryable<Notification> ApplyQuery(IQueryable<Notification> query, NotificationQuery queryParams) =>
        NotificationQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(NotificationQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(NotificationQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<int> CountUnreadByUserIdAsync(int userId) =>
        await DbSet.CountAsync(n => n.UserId == userId && !n.IsRead);

    public async Task<IEnumerable<Notification>> GetUnreadByUserIdAsync(int userId) =>
        await DbSet.Where(n => n.UserId == userId && !n.IsRead).ToListAsync();

    public async Task MarkAsReadAsync(int notificationId)
    {
        await DbSet
            .Where(n => n.Id == notificationId)
            .ExecuteUpdateAsync(s => s.SetProperty(n => n.IsRead, true));
    }

    public async Task MarkAllAsReadByUserIdAsync(int userId)
    {
        await DbSet
            .Where(n => n.UserId == userId && !n.IsRead)
            .ExecuteUpdateAsync(s => s.SetProperty(n => n.IsRead, true));
    }
}
