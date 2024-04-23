using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using shoptrack_be.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using shoptrack_be.Repositories;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private UserRepository _userService;

    public AuthController(UserRepository userService)
    {
        _userService = userService;
    }

    [HttpPost("sign-in")]
    public async Task<IActionResult> Signin([FromBody] AuthenticateRequest model)
    {
        var response = await _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
    {
        string userEmail = model.Email;

        // Call the repository method to send the forgot password email
        string message = await _userService.SendForgotPasswordEmail(userEmail);

        if (message == "Forgot password email sent successfully.")
        {
            return Ok(message);
        }
        else
        {
            return BadRequest(message);
        }
    }
}
