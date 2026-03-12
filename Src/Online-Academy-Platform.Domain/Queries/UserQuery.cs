using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class UserQuery
{
    public bool? Active { get; set; }
    public int? RoleId { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }

    public List<SortCriteria<UserSortField>> Sorts { get; set; } = new();

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}