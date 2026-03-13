namespace Online_Academy_Platform.Domain.Enums;

public enum CourseStatus
{
    Draft = 1,        // being prepared, not public
    Active = 2,       // currently running, students can enroll
    Finished = 3,     // course ended, students can review content
    Archived = 4,     // old course, hidden from catalog
    Cancelled = 5     // optional, soft delete or cancelled course
}
