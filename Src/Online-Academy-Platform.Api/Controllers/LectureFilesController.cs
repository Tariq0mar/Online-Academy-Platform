namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/lecture-files")]
public class LectureFilesController(ILectureFileService lectureFileService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<LectureFileResponse>> Upload(CreateLectureFileRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await lectureFileService.AddAsync(request));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LectureFileResponse>> GetById(int id)
        => Ok(await lectureFileService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LectureFileResponse>>> GetAll()
        => Ok(await lectureFileService.GetAllAsync());

    [HttpGet("lecture/{lectureId:int}")]
    public async Task<ActionResult<IEnumerable<LectureFileResponse>>> GetByLectureId(int lectureId)
        => Ok(await lectureFileService.GetByLectureIdAsync(lectureId));

    [HttpGet("{id:int}/download-url")]
    public async Task<ActionResult<string>> GetDownloadUrl(int id)
        => Ok(await lectureFileService.GetDownloadUrlAsync(id));

    [HttpPut("{id:int}")]
    public async Task<ActionResult<LectureFileResponse>> Update(int id, UpdateLectureFileRequest request)
        => Ok(await lectureFileService.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await lectureFileService.DeleteAsync(id);
        return NoContent();
    }
}