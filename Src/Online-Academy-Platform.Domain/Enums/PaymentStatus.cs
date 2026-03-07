namespace Online_Academy_Platform.Domain.Enums;

public enum PaymentStatus
{
    Pending = 1,    // payment started, waiting confirmation
    Completed = 2,  // successfully paid
    Failed = 3,     // failed or declined
    Cancelled = 4  // cancelled by user or system
}