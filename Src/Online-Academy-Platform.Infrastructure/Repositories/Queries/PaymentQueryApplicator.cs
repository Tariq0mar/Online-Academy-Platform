using Online_Academy_Platform.Domain.Entities;
using Online_Academy_Platform.Domain.Enums;
using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Queries;

internal static class PaymentQueryApplicator
{
    public static IQueryable<Payment> Apply(IQueryable<Payment> query, PaymentQuery parameters)
    {
        if (parameters.UserId.HasValue)
            query = query.Where(p => p.UserId == parameters.UserId.Value);
        if (parameters.EnrollmentId.HasValue)
            query = query.Where(p => p.EnrollmentId == parameters.EnrollmentId.Value);
        if (parameters.CourseId.HasValue)
            query = query.Where(p => p.CourseId == parameters.CourseId.Value);
        if (parameters.CouponId.HasValue)
            query = query.Where(p => p.CouponId == parameters.CouponId.Value);
        if (parameters.Currency.HasValue)
            query = query.Where(p => p.Currency == parameters.Currency.Value);
        if (parameters.PaymentMethod.HasValue)
            query = query.Where(p => p.PaymentMethod == parameters.PaymentMethod.Value);
        if (parameters.PaymentStatus.HasValue)
            query = query.Where(p => p.PaymentStatus == parameters.PaymentStatus.Value);
        if (parameters.MinOriginalAmount.HasValue)
            query = query.Where(p => p.OriginalAmount >= parameters.MinOriginalAmount.Value);
        if (parameters.MaxOriginalAmount.HasValue)
            query = query.Where(p => p.OriginalAmount <= parameters.MaxOriginalAmount.Value);
        if (parameters.MinFinalAmount.HasValue)
            query = query.Where(p => p.FinalAmount >= parameters.MinFinalAmount.Value);
        if (parameters.MaxFinalAmount.HasValue)
            query = query.Where(p => p.FinalAmount <= parameters.MaxFinalAmount.Value);
        if (parameters.CreatedAfter.HasValue)
            query = query.Where(p => p.CreatedAt >= parameters.CreatedAfter.Value);
        if (parameters.CreatedBefore.HasValue)
            query = query.Where(p => p.CreatedAt <= parameters.CreatedBefore.Value);

        return ApplySort(query, parameters.Sorts);
    }

    private static IQueryable<Payment> ApplySort(IQueryable<Payment> query, List<SortCriteria<PaymentSortField>> sorts)
    {
        if (sorts.Count == 0)
            return query.OrderBy(p => p.Id);

        IOrderedQueryable<Payment>? ordered = null;
        foreach (var sort in sorts)
        {
            ordered = (ordered, sort.Direction, sort.PropertyName) switch
            {
                (null, SortDirection.Asc, PaymentSortField.Id) => query.OrderBy(p => p.Id),
                (null, SortDirection.Desc, PaymentSortField.Id) => query.OrderByDescending(p => p.Id),
                (null, SortDirection.Asc, PaymentSortField.UserId) => query.OrderBy(p => p.UserId),
                (null, SortDirection.Desc, PaymentSortField.UserId) => query.OrderByDescending(p => p.UserId),
                (null, SortDirection.Asc, PaymentSortField.EnrollmentId) => query.OrderBy(p => p.EnrollmentId),
                (null, SortDirection.Desc, PaymentSortField.EnrollmentId) => query.OrderByDescending(p => p.EnrollmentId),
                (null, SortDirection.Asc, PaymentSortField.CourseId) => query.OrderBy(p => p.CourseId),
                (null, SortDirection.Desc, PaymentSortField.CourseId) => query.OrderByDescending(p => p.CourseId),
                (null, SortDirection.Asc, PaymentSortField.CouponId) => query.OrderBy(p => p.CouponId),
                (null, SortDirection.Desc, PaymentSortField.CouponId) => query.OrderByDescending(p => p.CouponId),
                (null, SortDirection.Asc, PaymentSortField.OriginalAmount) => query.OrderBy(p => p.OriginalAmount),
                (null, SortDirection.Desc, PaymentSortField.OriginalAmount) => query.OrderByDescending(p => p.OriginalAmount),
                (null, SortDirection.Asc, PaymentSortField.DiscountAmount) => query.OrderBy(p => p.DiscountAmount),
                (null, SortDirection.Desc, PaymentSortField.DiscountAmount) => query.OrderByDescending(p => p.DiscountAmount),
                (null, SortDirection.Asc, PaymentSortField.FinalAmount) => query.OrderBy(p => p.FinalAmount),
                (null, SortDirection.Desc, PaymentSortField.FinalAmount) => query.OrderByDescending(p => p.FinalAmount),
                (null, SortDirection.Asc, PaymentSortField.Currency) => query.OrderBy(p => p.Currency),
                (null, SortDirection.Desc, PaymentSortField.Currency) => query.OrderByDescending(p => p.Currency),
                (null, SortDirection.Asc, PaymentSortField.PaymentMethod) => query.OrderBy(p => p.PaymentMethod),
                (null, SortDirection.Desc, PaymentSortField.PaymentMethod) => query.OrderByDescending(p => p.PaymentMethod),
                (null, SortDirection.Asc, PaymentSortField.PaymentStatus) => query.OrderBy(p => p.PaymentStatus),
                (null, SortDirection.Desc, PaymentSortField.PaymentStatus) => query.OrderByDescending(p => p.PaymentStatus),
                (null, SortDirection.Asc, PaymentSortField.CreatedAt) => query.OrderBy(p => p.CreatedAt),
                (null, SortDirection.Desc, PaymentSortField.CreatedAt) => query.OrderByDescending(p => p.CreatedAt),
                (var o, SortDirection.Asc, PaymentSortField.Id) => o.ThenBy(p => p.Id),
                (var o, SortDirection.Desc, PaymentSortField.Id) => o.ThenByDescending(p => p.Id),
                (var o, SortDirection.Asc, PaymentSortField.UserId) => o.ThenBy(p => p.UserId),
                (var o, SortDirection.Desc, PaymentSortField.UserId) => o.ThenByDescending(p => p.UserId),
                (var o, SortDirection.Asc, PaymentSortField.EnrollmentId) => o.ThenBy(p => p.EnrollmentId),
                (var o, SortDirection.Desc, PaymentSortField.EnrollmentId) => o.ThenByDescending(p => p.EnrollmentId),
                (var o, SortDirection.Asc, PaymentSortField.CourseId) => o.ThenBy(p => p.CourseId),
                (var o, SortDirection.Desc, PaymentSortField.CourseId) => o.ThenByDescending(p => p.CourseId),
                (var o, SortDirection.Asc, PaymentSortField.CouponId) => o.ThenBy(p => p.CouponId),
                (var o, SortDirection.Desc, PaymentSortField.CouponId) => o.ThenByDescending(p => p.CouponId),
                (var o, SortDirection.Asc, PaymentSortField.OriginalAmount) => o.ThenBy(p => p.OriginalAmount),
                (var o, SortDirection.Desc, PaymentSortField.OriginalAmount) => o.ThenByDescending(p => p.OriginalAmount),
                (var o, SortDirection.Asc, PaymentSortField.DiscountAmount) => o.ThenBy(p => p.DiscountAmount),
                (var o, SortDirection.Desc, PaymentSortField.DiscountAmount) => o.ThenByDescending(p => p.DiscountAmount),
                (var o, SortDirection.Asc, PaymentSortField.FinalAmount) => o.ThenBy(p => p.FinalAmount),
                (var o, SortDirection.Desc, PaymentSortField.FinalAmount) => o.ThenByDescending(p => p.FinalAmount),
                (var o, SortDirection.Asc, PaymentSortField.Currency) => o.ThenBy(p => p.Currency),
                (var o, SortDirection.Desc, PaymentSortField.Currency) => o.ThenByDescending(p => p.Currency),
                (var o, SortDirection.Asc, PaymentSortField.PaymentMethod) => o.ThenBy(p => p.PaymentMethod),
                (var o, SortDirection.Desc, PaymentSortField.PaymentMethod) => o.ThenByDescending(p => p.PaymentMethod),
                (var o, SortDirection.Asc, PaymentSortField.PaymentStatus) => o.ThenBy(p => p.PaymentStatus),
                (var o, SortDirection.Desc, PaymentSortField.PaymentStatus) => o.ThenByDescending(p => p.PaymentStatus),
                (var o, SortDirection.Asc, PaymentSortField.CreatedAt) => o.ThenBy(p => p.CreatedAt),
                (var o, SortDirection.Desc, PaymentSortField.CreatedAt) => o.ThenByDescending(p => p.CreatedAt),
                _ => ordered ?? query.OrderBy(p => p.Id)
            };
        }

        return ordered ?? query;
    }
}
