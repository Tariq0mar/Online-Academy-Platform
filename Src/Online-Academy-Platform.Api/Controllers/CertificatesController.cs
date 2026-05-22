namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificatesController(ICertificateService certificateService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CertificateResponse>> Issue(IssueCertificateRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await certificateService.IssueAsync(request));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CertificateResponse>> GetById(int id)
        => Ok(await certificateService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CertificateResponse>>> GetAll()
        => Ok(await certificateService.GetAllAsync());

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<CertificateResponse>>> GetByUserId(int userId)
        => Ok(await certificateService.GetByUserIdAsync(userId));

    [HttpGet("user/{userId:int}/course/{courseId:int}")]
    public async Task<ActionResult<CertificateResponse>> GetByUserAndCourse(int userId, int courseId)
        => Ok(await certificateService.GetByUserAndCourseAsync(userId, courseId));

    [HttpGet("user/{userId:int}/course/{courseId:int}/exists")]
    public async Task<ActionResult<bool>> HasCertificate(int userId, int courseId)
        => Ok(await certificateService.HasCertificateAsync(userId, courseId));

    [HttpGet("verify/{certificateCode}")]
    public async Task<ActionResult<bool>> Verify(string certificateCode)
        => Ok(await certificateService.VerifyAsync(certificateCode));

    [HttpPut("{id:int}/revoke")]
    public async Task<IActionResult> Revoke(int id)
    {
        await certificateService.RevokeAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await certificateService.DeleteAsync(id);
        return NoContent();
    }
}