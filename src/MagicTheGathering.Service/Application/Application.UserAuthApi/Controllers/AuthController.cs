using Microsoft.AspNetCore.Mvc;
using Application.UserAuthApi.Services;
using Application.UserAuthApi.Models;
using Application.UserAuthApi.Models.Request;
using System.Threading.Tasks;
using Domain.UserAuthApi.Interfaces.Services;

namespace Application.UserAuthApi.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            // Validate the login request model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Call the authentication service to validate credentials and generate a token
            var token = await _authService.AuthenticateUserAsync(model.Username, model.Password);

            if (token == null)
            {
                return Unauthorized(); // Invalid credentials
            }

            // Return the token in the response
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            // Validate the register request model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Call the authentication service to register the user
            var result = await _authService.RegisterUserAsync(model.Username, model.Password);

            if (!result.Success)
            {
                return BadRequest(result.Message); // Registration failed
            }

            // Return a success response
            return Ok(new { Message = "Registration successful!" });
        }
    }
}
