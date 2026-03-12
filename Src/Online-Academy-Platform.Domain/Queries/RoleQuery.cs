using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class RoleQuery
{
    public List<SortCriteria<RoleSortField>> Sorts { get; set; } = new();

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}