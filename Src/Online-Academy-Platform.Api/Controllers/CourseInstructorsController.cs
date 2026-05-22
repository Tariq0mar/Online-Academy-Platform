namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/course-instructors")]
public class CourseInstructorsController(ICourseInstructorService courseInstructorService) : ControllerBase
{
    [HttpPost("assign")]
    public async Task<ActionResult<CourseInstructorResponse>> Assign(AssignInstructorRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await courseInstructorService.AssignAsync(request));

    [HttpPost("set-primary")]
    public async Task<ActionResult<CourseInstructorResponse>> SetPrimary(AssignInstructorRequest request)
        => Ok(await courseInstructorService.SetPrimaryInstructorAsync(request));

    [HttpPost("remove")]
    public async Task<IActionResult> Remove(RemoveInstructorRequest request)
    {
        await courseInstructorService.RemoveAsync(request);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CourseInstructorResponse>> GetById(int id)
        => Ok(await courseInstructorService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseInstructorResponse>>> GetAll()
        => Ok(await courseInstructorService.GetAllAsync());

    [HttpGet("course/{courseId:int}")]
    public async Task<ActionResult<IEnumerable<CourseInstructorResponse>>> GetByCourseId(int courseId)
        => Ok(await courseInstructorService.GetByCourseIdAsync(courseId));

    [HttpGet("instructor/{instructorId:int}")]
    public async Task<ActionResult<IEnumerable<CourseInstructorResponse>>> GetByInstructorId(int instructorId)
        => Ok(await courseInstructorService.GetByInstructorIdAsync(instructorId));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await courseInstructorService.DeleteAsync(id);
        return NoContent();
    }
}