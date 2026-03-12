using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public class NotificationQuery
{
    public int? UserId { get; set; }
    public bool? IsRead { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }

    public List<SortCriteria<NotificationSortField>> Sorts { get; set; } = new();

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}