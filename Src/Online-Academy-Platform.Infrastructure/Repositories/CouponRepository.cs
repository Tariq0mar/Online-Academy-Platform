using Microsoft.EntityFrameworkCore;
using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Interfaces.Repositories;
using Online_Academy_Platform.Domain.Queries;
using Online_Academy_Platform.Infrastructure.Persistence;
using Online_Academy_Platform.Infrastructure.Repositories.Common;
using Online_Academy_Platform.Infrastructure.Repositories.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories;

public class CouponRepository(ApplicationDbContext context)
    : QueryableRepository<Coupon, CouponQuery>(context), ICouponRepository
{
    protected override IQueryable<Coupon> ApplyQuery(IQueryable<Coupon> query, CouponQuery queryParams) =>
        CouponQueryApplicator.Apply(query, queryParams);

    protected override int GetPage(CouponQuery query) => QueryHelper.GetPage(query.Pagination);

    protected override int GetPageSize(CouponQuery query) => QueryHelper.GetPageSize(query.Pagination);

    public async Task<Coupon?> GetByCodeAsync(string code) =>
        await DbSet.FirstOrDefaultAsync(c => c.Code == code);

    public async Task<bool> ExistsByCodeAsync(string code) =>
        await DbSet.AnyAsync(c => c.Code == code);

    public async Task<bool> ExistsByCodeAsync(string code, int excludeCouponId) =>
        await DbSet.AnyAsync(c => c.Code == code && c.Id != excludeCouponId);

    public async Task IncrementUsedCountAsync(int couponId)
    {
        await DbSet
            .Where(c => c.Id == couponId)
            .ExecuteUpdateAsync(s => s.SetProperty(c => c.UsedCount, c => c.UsedCount + 1));
    }
}
