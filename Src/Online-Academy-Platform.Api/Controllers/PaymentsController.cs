namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController(IPaymentService paymentService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<PaymentResponse>> Create(CreatePaymentRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await paymentService.CreatePaymentAsync(request));

    [HttpPut("update-status")]
    public async Task<IActionResult> UpdateStatus(UpdatePaymentStatusRequest request)
    {
        await paymentService.UpdateStatusAsync(request);
        return NoContent();
    }

    [HttpPut("{id:int}/complete")]
    public async Task<IActionResult> Complete(int id)
    {
        await paymentService.CompleteAsync(id);
        return NoContent();
    }

    [HttpPut("{id:int}/fail")]
    public async Task<IActionResult> Fail(int id)
    {
        await paymentService.FailAsync(id);
        return NoContent();
    }

    [HttpPut("{id:int}/cancel")]
    public async Task<IActionResult> Cancel(int id)
    {
        await paymentService.CancelAsync(id);
        return NoContent();
    }

    [HttpPost("{id:int}/refund")]
    public async Task<ActionResult<PaymentResponse>> Refund(int id)
        => Ok(await paymentService.RefundAsync(id));

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaymentResponse>> GetById(int id)
        => Ok(await paymentService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentResponse>>> GetAll()
        => Ok(await paymentService.GetAllAsync());

    [HttpGet("transaction/{transactionId}")]
    public async Task<ActionResult<PaymentResponse>> GetByTransactionId(string transactionId)
        => Ok(await paymentService.GetByTransactionIdAsync(transactionId));

    [HttpGet("user/{userId:int}")]
    public async Task<ActionResult<IEnumerable<PaymentResponse>>> GetByUserId(int userId)
        => Ok(await paymentService.GetByUserIdAsync(userId));

    [HttpGet("enrollment/{enrollmentId:int}")]
    public async Task<ActionResult<IEnumerable<PaymentResponse>>> GetByEnrollmentId(int enrollmentId)
        => Ok(await paymentService.GetByEnrollmentIdAsync(enrollmentId));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await paymentService.DeleteAsync(id);
        return NoContent();
    }
}