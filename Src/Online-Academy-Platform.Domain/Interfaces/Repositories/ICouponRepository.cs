using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Repositories;

public interface ICouponRepository : IRepository<Coupon>
{
    Task<IEnumerable<Coupon>> QueryAsync(CouponQuery query);
}