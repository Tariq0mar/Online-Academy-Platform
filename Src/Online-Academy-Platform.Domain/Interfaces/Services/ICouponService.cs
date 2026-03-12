using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Domain.Interfaces.Services;

public interface ICouponService: IService<Coupon>
{
    Task<Coupon> QueryAsync(CouponQuery query);
}