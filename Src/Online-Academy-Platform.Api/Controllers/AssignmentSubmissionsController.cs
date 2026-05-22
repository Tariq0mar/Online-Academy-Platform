namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/assignment-submissions")]
public class AssignmentSubmissionsController(IAssignmentSubmissionService assignmentSubmissionService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<AssignmentSubmissionResponse>> Submit(SubmitAssignmentRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await assignmentSubmissionService.SubmitAsync(request));

    [HttpPost("{id:int}/resubmit")]
    public async Task<ActionResult<AssignmentSubmissionResponse>> Resubmit(int id, SubmitAssignmentRequest request)
        => Ok(await assignmentSubmissionService.ResubmitAsync(id, request));

    [HttpPut("{id:int}/grade")]
    public async Task<IActionResult> Grade(int id, GradeAssignmentRequest request)
    {
        request = request with { SubmissionId = id };
        await assignmentSubmissionService.GradeAsync(request);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<AssignmentSubmissionResponse>> GetById(int id)
        => Ok(await assignmentSubmissionService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssignmentSubmissionResponse>>> GetAll()
        => Ok(await assignmentSubmissionService.GetAllAsync());

    [HttpGet("assignment/{assignmentId:int}")]
    public async Task<ActionResult<IEnumerable<AssignmentSubmissionResponse>>> GetByAssignmentId(int assignmentId)
        => Ok(await assignmentSubmissionService.GetByAssignmentIdAsync(assignmentId));

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<AssignmentSubmissionResponse>>> GetByUserId(int userId)
        => Ok(await assignmentSubmissionService.GetByUserIdAsync(userId));

    [HttpGet("assignment/{assignmentId:int}/user/{userId:int}")]
    public async Task<ActionResult<AssignmentSubmissionResponse>> GetByAssignmentAndUser(int assignmentId, int userId)
        => Ok(await assignmentSubmissionService.GetByAssignmentAndUserAsync(assignmentId, userId));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await assignmentSubmissionService.DeleteAsync(id);
        return NoContent();
    }
}