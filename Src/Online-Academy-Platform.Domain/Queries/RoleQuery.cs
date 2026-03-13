using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class RoleQuery
{
    public List<SortCriteria<RoleSortField>> Sorts { get; set; } = new();

    public Pagination Pagination { get; set; } = new Pagination();
}