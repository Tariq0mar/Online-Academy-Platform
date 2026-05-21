namespace Online_Academy_Platform.Domain.Constants;

public static class EntityUniquenessRules
{
    public const string UserEmail = "User.Email must be unique.";
    public const string EnrollmentUserCourse = "Enrollment (UserId, CourseId) must be unique.";
    public const string CourseInstructorCourseUser = "CourseInstructor (CourseId, InstructorId) must be unique.";
    public const string CoursePrimaryInstructor = "CourseInstructor: at most one primary instructor per CourseId.";
    public const string AttendanceLectureUser = "Attendance (LectureId, UserId) must be unique.";
    public const string AssignmentSubmissionAssignmentUser = "AssignmentSubmission (AssignmentId, UserId) must be unique per attempt policy.";
    public const string CertificateUserCourse = "Certificate (UserId, CourseId) must be unique.";
    public const string CouponCode = "Coupon.Code must be unique.";
}
