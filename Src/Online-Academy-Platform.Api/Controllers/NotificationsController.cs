namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController(INotificationService notificationService) : ControllerBase
{
    [HttpPost("send")]
    public async Task<ActionResult<NotificationResponse>> Send(SendNotificationRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await notificationService.SendAsync(request));

    [HttpPost("send-bulk")]
    public async Task<ActionResult<IEnumerable<NotificationResponse>>> SendBulk(SendBulkNotificationRequest request)
        => Ok(await notificationService.SendBulkAsync(request));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<NotificationResponse>> GetById(int id)
        => Ok(await notificationService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NotificationResponse>>> GetAll()
        => Ok(await notificationService.GetAllAsync());

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<NotificationResponse>>> GetByUserId(int userId)
        => Ok(await notificationService.GetByUserIdAsync(userId));

    [HttpGet("user/{userId:int}/unread-count")]
    public async Task<ActionResult<int>> GetUnreadCount(int userId)
        => Ok(await notificationService.GetUnreadCountAsync(userId));

    [HttpPut("{id:int}/mark-as-read")]
    public async Task<IActionResult> MarkAsRead(int id)
    {
        await notificationService.MarkAsReadAsync(id);
        return NoContent();
    }

    [HttpPut("user/{userId:int}/mark-all-as-read")]
    public async Task<IActionResult> MarkAllAsRead(int userId)
    {
        await notificationService.MarkAllAsReadAsync(userId);
        return NoContent();
    }

    [HttpDelete("delete-old")]
    public async Task<IActionResult> DeleteOld([FromQuery] int daysOld)
    {
        await notificationService.DeleteOldAsync(daysOld);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await notificationService.DeleteAsync(id);
        return NoContent();
    }
}