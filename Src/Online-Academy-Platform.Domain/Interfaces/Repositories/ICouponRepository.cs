using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ICouponRepository : IQueryableRepository<Coupon, CouponQuery>
{
    Task<Coupon?> GetByCodeAsync(string code);

    Task<bool> ExistsByCodeAsync(string code);

    Task<bool> ExistsByCodeAsync(string code, int excludeCouponId);

    Task IncrementUsedCountAsync(int couponId);
}
