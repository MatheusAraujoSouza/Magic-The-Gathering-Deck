using Microsoft.AspNetCore.Mvc;
using Application.UserAuthApi.Services; // Assuming this is the namespace for your application services
using Application.UserAuthApi.Models; // Assuming this is the namespace for your application models

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
        public IActionResult Login(LoginRequestModel model)
        {
            // Validate the login request model

            // Call the authentication service to validate credentials and generate a token
            var token = _authService.AuthenticateUser(model.Username, model.Password);

            if (token == null)
            {
                return Unauthorized(); // Invalid credentials
            }

            // Return the token in the response
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequestModel model)
        {
            // Validate the register request model

            // Call the authentication service to register the user
            var result = _authService.RegisterUser(model.Username, model.Password);

            if (!result.Success)
            {
                return BadRequest(result.Message); // Registration failed
            }

            // Return a success response
            return Ok(new { Message = "Registration successful!" });
        }
    }
}
