using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context)
    : QueryableRepository<User, UserQuery>(context), IUserRepository
{
    protected override IQueryable<User> ApplyQuery(IQueryable<User> query, UserQuery queryParams) =>
        UserQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(UserQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(UserQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<User?> GetByEmailAsync(string email) =>
        await DbSet.FirstOrDefaultAsync(u => u.Email == email);

    public async Task<bool> ExistsByEmailAsync(string email) =>
        await DbSet.AnyAsync(u => u.Email == email);

    public async Task<bool> ExistsByEmailAsync(string email, int excludeUserId) =>
        await DbSet.AnyAsync(u => u.Email == email && u.Id != excludeUserId);

    public async Task<IEnumerable<User>> GetByRoleAsync(UserRole role) =>
        await DbSet.Where(u => u.Role == role).ToListAsync();
}
