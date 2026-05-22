namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController(ICourseService courseService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CourseResponse>> Create(CreateCourseRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await courseService.AddAsync(request));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CourseResponse>> GetById(int id)
        => Ok(await courseService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseResponse>>> GetAll()
        => Ok(await courseService.GetAllAsync());

    [HttpGet("instructor/{instructorId:int}")]
    public async Task<ActionResult<IEnumerable<CourseResponse>>> GetByInstructorId(int instructorId)
        => Ok(await courseService.GetByInstructorIdAsync(instructorId));

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CourseResponse>> Update(int id, UpdateCourseRequest request)
        => Ok(await courseService.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await courseService.DeleteAsync(id);
        return NoContent();
    }
}