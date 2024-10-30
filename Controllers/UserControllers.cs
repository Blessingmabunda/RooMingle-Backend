using Microsoft.AspNetCore.Mvc;
using UserApi.Models;
using System.Threading.Tasks;

namespace UserApi.Controllers
{
    [ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(User user)
    {
        var registeredUser = await _userService.RegisterAsync(user);
        return CreatedAtAction(nameof(Register), new { id = registeredUser.Id }, registeredUser);
    }

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(string username, string password)
    {
        var user = await _userService.LoginAsync(username, password);
        if (user == null)
        {
            return Unauthorized(); // Invalid credentials
        }
        return user; // Successful login
    }

    [HttpPut("update")]
    public async Task<ActionResult<User>> UpdateUser(User user)
    {
        var updatedUser = await _userService.UpdateUserAsync(user);
        if (updatedUser == null)
        {
            return NotFound(); // User not found
        }
        return Ok(updatedUser); // Return updated user
    }

    [HttpDelete("delete/{username}")]
    public async Task<ActionResult> DeleteUser(string username)
    {
        await _userService.DeleteUserAsync(username);
        return NoContent(); // Successfully deleted
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users); // Return all users
    }
}

}
