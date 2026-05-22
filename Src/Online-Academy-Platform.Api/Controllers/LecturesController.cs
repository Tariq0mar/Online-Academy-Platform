namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LecturesController(ILectureService lectureService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<LectureResponse>> Create(CreateLectureRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await lectureService.AddAsync(request));

    [HttpPost("course/{courseId:int}/reorder")]
    public async Task<IActionResult> Reorder(int courseId, ReorderLecturesRequest request)
    {
        await lectureService.ReorderAsync(courseId, request);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LectureResponse>> GetById(int id)
        => Ok(await lectureService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LectureResponse>>> GetAll()
        => Ok(await lectureService.GetAllAsync());

    [HttpGet("course/{courseId:int}")]
    public async Task<ActionResult<IEnumerable<LectureResponse>>> GetByCourseId(int courseId)
        => Ok(await lectureService.GetByCourseIdAsync(courseId));

    [HttpPut("{id:int}")]
    public async Task<ActionResult<LectureResponse>> Update(int id, UpdateLectureRequest request)
        => Ok(await lectureService.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await lectureService.DeleteAsync(id);
        return NoContent();
    }
}