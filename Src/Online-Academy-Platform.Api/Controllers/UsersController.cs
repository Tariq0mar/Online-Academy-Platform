namespace Online_Academy_Platform.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<ActionResult<UserResponse>> Register(RegisterUserRequest request)
        => CreatedAtAction(nameof(GetById), new { id = 0 }, await userService.RegisterAsync(request));

    [HttpPost("login")]
    public async Task<ActionResult<UserResponse>> Login(LoginRequest request)
        => Ok(await userService.LoginAsync(request));

    [HttpPost("logout/{userId:int}")]
    public async Task<IActionResult> Logout(int userId)
    {
        await userService.LogoutAsync(userId);
        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserResponse>> GetById(int id)
        => Ok(await userService.GetByIdAsync(id));

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
        => Ok(await userService.GetAllAsync());

    [HttpGet("role/{role}")]
    public async Task<ActionResult<IEnumerable<UserResponse>>> GetByRole(string role)
        => Ok(await userService.GetByRoleAsync(role));

    [HttpGet("email/{email}")]
    public async Task<ActionResult<UserResponse>> GetByEmail(string email)
        => Ok(await userService.GetByEmailAsync(email));

    [HttpGet("email/{email}/exists")]
    public async Task<ActionResult<bool>> EmailExists(string email)
        => Ok(await userService.EmailExistsAsync(email));

    [HttpPut("{id:int}")]
    public async Task<ActionResult<UserResponse>> Update(int id, UpdateUserRequest request)
        => Ok(await userService.UpdateAsync(id, request));

    [HttpPut("{id:int}/change-password")]
    public async Task<IActionResult> ChangePassword(int id, ChangePasswordRequest request)
    {
        await userService.ChangePasswordAsync(id, request);
        return NoContent();
    }

    [HttpPut("{id:int}/activate")]
    public async Task<IActionResult> Activate(int id)
    {
        await userService.ActivateAsync(id);
        return NoContent();
    }

    [HttpPut("{id:int}/deactivate")]
    public async Task<IActionResult> Deactivate(int id)
    {
        await userService.DeactivateAsync(id);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await userService.DeleteAsync(id);
        return NoContent();
    }
}