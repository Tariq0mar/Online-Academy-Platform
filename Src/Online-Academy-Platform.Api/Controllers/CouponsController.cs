namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponsController(ICouponService couponService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CouponResponse>> Create(CreateCouponRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await couponService.AddAsync(request));

    [HttpGet("calculate-discount")]
    public async Task<ActionResult<CouponDiscountResponse>> CalculateDiscount([FromQuery] decimal originalAmount, [FromQuery] string couponCode)
        => Ok(await couponService.CalculateDiscountAsync(originalAmount, couponCode));

    [HttpGet("validate-for-course")]
    public async Task<ActionResult<bool>> ValidateForCourse([FromQuery] string code, [FromQuery] int courseId)
        => Ok(await couponService.ValidateForCourseAsync(code, courseId));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CouponResponse>> GetById(int id)
        => Ok(await couponService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CouponResponse>>> GetAll()
        => Ok(await couponService.GetAllAsync());

    [HttpGet("code/{code}")]
    public async Task<ActionResult<CouponResponse>> GetByCode(string code)
        => Ok(await couponService.GetByCodeAsync(code));

    [HttpGet("code/{code}/is-valid")]
    public async Task<ActionResult<bool>> IsValid(string code)
        => Ok(await couponService.IsValidAsync(code));

    [HttpGet("active")]
    public async Task<ActionResult<IEnumerable<CouponResponse>>> GetActive()
        => Ok(await couponService.GetActiveCouponsAsync());

    [HttpPut("{id:int}")]
    public async Task<ActionResult<CouponResponse>> Update(int id, UpdateCouponRequest request)
        => Ok(await couponService.UpdateAsync(id, request));

    [HttpPut("{id:int}/deactivate")]
    public async Task<IActionResult> Deactivate(int id)
    {
        await couponService.DeactivateAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await couponService.DeleteAsync(id);
        return NoContent();
    }
}