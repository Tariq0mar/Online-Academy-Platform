using Online_Academy_Platform.Domain.Queries;

namespace Online_Academy_Platform.Infrastructure.Repositories.Common;

internal static class QueryHelper
{
    public static int GetPage(Pagination pagination) => Math.Max(1, pagination.Page);

    public static int GetPageSize(Pagination pagination) => Math.Max(1, pagination.PageSize);
}
