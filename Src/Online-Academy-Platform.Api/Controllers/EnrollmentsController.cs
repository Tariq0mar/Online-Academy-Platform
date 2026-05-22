namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController(IEnrollmentService enrollmentService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<EnrollmentResponse>> Enroll(EnrollRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await enrollmentService.EnrollAsync(request));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EnrollmentResponse>> GetById(int id)
        => Ok(await enrollmentService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnrollmentResponse>>> GetAll()
        => Ok(await enrollmentService.GetAllAsync());

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<EnrollmentResponse>>> GetByUserId(int userId)
        => Ok(await enrollmentService.GetByUserIdAsync(userId));

    [HttpGet("course/{courseId:int}")]
    public async Task<ActionResult<IEnumerable<EnrollmentResponse>>> GetByCourseId(int courseId)
        => Ok(await enrollmentService.GetByCourseIdAsync(courseId));

    [HttpGet("user/{userId:int}/course/{courseId:int}")]
    public async Task<ActionResult<EnrollmentResponse>> GetByUserAndCourse(int userId, int courseId)
        => Ok(await enrollmentService.GetByUserAndCourseAsync(userId, courseId));

    [HttpGet("user/{userId:int}/course/{courseId:int}/exists")]
    public async Task<ActionResult<bool>> IsEnrolled(int userId, int courseId)
        => Ok(await enrollmentService.IsEnrolledAsync(userId, courseId));

    [HttpPut("{id:int}/cancel")]
    public async Task<IActionResult> Cancel(int id)
    {
        await enrollmentService.CancelAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await enrollmentService.DeleteAsync(id);
        return NoContent();
    }
}