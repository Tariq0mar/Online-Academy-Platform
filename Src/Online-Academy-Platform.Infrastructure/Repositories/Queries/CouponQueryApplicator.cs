using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class CouponQueryApplicator
{
    public static IQueryable<Coupon> Apply(IQueryable<Coupon> query, CouponQuery parameters)
    {
        if (!string.IsNullOrWhiteSpace(parameters.Code))
            query = query.Where(c => c.Code.Contains(parameters.Code));
        if (parameters.DiscountType.HasValue)
            query = query.Where(c => c.DiscountType == parameters.DiscountType.Value);
        if (parameters.IsActive.HasValue)
            query = query.Where(c => c.IsActive == parameters.IsActive.Value);
        if (parameters.ValidFromAfter.HasValue)
            query = query.Where(c => c.ValidFrom >= parameters.ValidFromAfter.Value);
        if (parameters.ValidFromBefore.HasValue)
            query = query.Where(c => c.ValidFrom <= parameters.ValidFromBefore.Value);
        if (parameters.ValidUntilAfter.HasValue)
            query = query.Where(c => c.ValidUntil >= parameters.ValidUntilAfter.Value);
        if (parameters.ValidUntilBefore.HasValue)
            query = query.Where(c => c.ValidUntil <= parameters.ValidUntilBefore.Value);

        if (parameters.Sorts.Count == 0)
            return query.OrderBy(c => c.Id);

        IOrderedQueryable<Coupon>? ordered = null;
        foreach (var sort in parameters.Sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, CouponSortField.Id) => query.OrderBy(c => c.Id),
                (null, SortDirection.Desc, CouponSortField.Id) => query.OrderByDescending(c => c.Id),
                (null, SortDirection.Asc, CouponSortField.Code) => query.OrderBy(c => c.Code),
                (null, SortDirection.Desc, CouponSortField.Code) => query.OrderByDescending(c => c.Code),
                (null, SortDirection.Asc, CouponSortField.DiscountType) => query.OrderBy(c => c.DiscountType),
                (null, SortDirection.Desc, CouponSortField.DiscountType) => query.OrderByDescending(c => c.DiscountType),
                (null, SortDirection.Asc, CouponSortField.DiscountValue) => query.OrderBy(c => c.DiscountValue),
                (null, SortDirection.Desc, CouponSortField.DiscountValue) => query.OrderByDescending(c => c.DiscountValue),
                (null, SortDirection.Asc, CouponSortField.MaxUses) => query.OrderBy(c => c.MaxUses),
                (null, SortDirection.Desc, CouponSortField.MaxUses) => query.OrderByDescending(c => c.MaxUses),
                (null, SortDirection.Asc, CouponSortField.UsedCount) => query.OrderBy(c => c.UsedCount),
                (null, SortDirection.Desc, CouponSortField.UsedCount) => query.OrderByDescending(c => c.UsedCount),
                (null, SortDirection.Asc, CouponSortField.ValidFrom) => query.OrderBy(c => c.ValidFrom),
                (null, SortDirection.Desc, CouponSortField.ValidFrom) => query.OrderByDescending(c => c.ValidFrom),
                (null, SortDirection.Asc, CouponSortField.ValidUntil) => query.OrderBy(c => c.ValidUntil),
                (null, SortDirection.Desc, CouponSortField.ValidUntil) => query.OrderByDescending(c => c.ValidUntil),
                (null, SortDirection.Asc, CouponSortField.CreatedAt) => query.OrderBy(c => c.CreatedAt),
                (null, SortDirection.Desc, CouponSortField.CreatedAt) => query.OrderByDescending(c => c.CreatedAt),
                (null, SortDirection.Asc, CouponSortField.IsActive) => query.OrderBy(c => c.IsActive),
                (null, SortDirection.Desc, CouponSortField.IsActive) => query.OrderByDescending(c => c.IsActive),
                (var o, SortDirection.Asc, CouponSortField.Id) => o.ThenBy(c => c.Id),
                (var o, SortDirection.Desc, CouponSortField.Id) => o.ThenByDescending(c => c.Id),
                (var o, SortDirection.Asc, CouponSortField.Code) => o.ThenBy(c => c.Code),
                (var o, SortDirection.Desc, CouponSortField.Code) => o.ThenByDescending(c => c.Code),
                (var o, SortDirection.Asc, CouponSortField.DiscountType) => o.ThenBy(c => c.DiscountType),
                (var o, SortDirection.Desc, CouponSortField.DiscountType) => o.ThenByDescending(c => c.DiscountType),
                (var o, SortDirection.Asc, CouponSortField.DiscountValue) => o.ThenBy(c => c.DiscountValue),
                (var o, SortDirection.Desc, CouponSortField.DiscountValue) => o.ThenByDescending(c => c.DiscountValue),
                (var o, SortDirection.Asc, CouponSortField.MaxUses) => o.ThenBy(c => c.MaxUses),
                (var o, SortDirection.Desc, CouponSortField.MaxUses) => o.ThenByDescending(c => c.MaxUses),
                (var o, SortDirection.Asc, CouponSortField.UsedCount) => o.ThenBy(c => c.UsedCount),
                (var o, SortDirection.Desc, CouponSortField.UsedCount) => o.ThenByDescending(c => c.UsedCount),
                (var o, SortDirection.Asc, CouponSortField.ValidFrom) => o.ThenBy(c => c.ValidFrom),
                (var o, SortDirection.Desc, CouponSortField.ValidFrom) => o.ThenByDescending(c => c.ValidFrom),
                (var o, SortDirection.Asc, CouponSortField.ValidUntil) => o.ThenBy(c => c.ValidUntil),
                (var o, SortDirection.Desc, CouponSortField.ValidUntil) => o.ThenByDescending(c => c.ValidUntil),
                (var o, SortDirection.Asc, CouponSortField.CreatedAt) => o.ThenBy(c => c.CreatedAt),
                (var o, SortDirection.Desc, CouponSortField.CreatedAt) => o.ThenByDescending(c => c.CreatedAt),
                (var o, SortDirection.Asc, CouponSortField.IsActive) => o.ThenBy(c => c.IsActive),
                (var o, SortDirection.Desc, CouponSortField.IsActive) => o.ThenByDescending(c => c.IsActive),
                _ => ordered ?? query.OrderBy(c => c.Id)
            };
        }
        return ordered ?? query;
    }
}