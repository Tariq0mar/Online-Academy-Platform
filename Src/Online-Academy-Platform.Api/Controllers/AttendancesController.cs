namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendancesController(IAttendanceService attendanceService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<AttendanceResponse>> Record(RecordAttendanceRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await attendanceService.RecordAsync(request));

    [HttpPost("bulk")]
    public async Task<ActionResult<IEnumerable<AttendanceResponse>>> BulkRecord(IEnumerable<RecordAttendanceRequest> records)
        => Ok(await attendanceService.BulkRecordAsync(records));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AttendanceResponse>> GetById(int id)
        => Ok(await attendanceService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AttendanceResponse>>> GetAll()
        => Ok(await attendanceService.GetAllAsync());

    [HttpGet("lecture/{lectureId:int}")]
    public async Task<ActionResult<IEnumerable<AttendanceResponse>>> GetByLectureId(int lectureId)
        => Ok(await attendanceService.GetByLectureIdAsync(lectureId));

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<AttendanceResponse>>> GetByUserId(int userId)
        => Ok(await attendanceService.GetByUserIdAsync(userId));

    [HttpGet("lecture/{lectureId:int}/user/{userId:int}")]
    public async Task<ActionResult<AttendanceResponse>> GetByLectureAndUser(int lectureId, int userId)
        => Ok(await attendanceService.GetByLectureAndUserAsync(lectureId, userId));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await attendanceService.DeleteAsync(id);
        return NoContent();
    }
}