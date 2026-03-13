namespace Online_Academy_Platform.Domain.Enums;

public enum SubmissionStatus
{
    Pending,   // waiting for grading
    Graded,    // graded
    Late,      // submitted after deadline
    Rejected   // not accepted / invalid submission
}