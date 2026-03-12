using Online_Academy_Platform.Domain.Enums;

namespace Online_Academy_Platform.Domain.Queries;

public record SortCriteria<TSortField>(TSortField PropertyName, SortDirection Direction);