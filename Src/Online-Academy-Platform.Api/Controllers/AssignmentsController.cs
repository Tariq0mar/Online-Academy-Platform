namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssignmentsController(IAssignmentService assignmentService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<AssignmentResponse>> Create(CreateAssignmentRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await assignmentService.AddAsync(request));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AssignmentResponse>> GetById(int id)
        => Ok(await assignmentService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssignmentResponse>>> GetAll()
        => Ok(await assignmentService.GetAllAsync());

    [HttpGet("course/{courseId:int}")]
    public async Task<ActionResult<IEnumerable<AssignmentResponse>>> GetByCourseId(int courseId)
        => Ok(await assignmentService.GetByCourseIdAsync(courseId));

    [HttpPut("{id:int}")]
    public async Task<ActionResult<AssignmentResponse>> Update(int id, UpdateAssignmentRequest request)
        => Ok(await assignmentService.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await assignmentService.DeleteAsync(id);
        return NoContent();
    }
}