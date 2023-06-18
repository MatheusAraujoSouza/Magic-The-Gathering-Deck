using Microsoft.AspNetCore.Mvc;
using Application.UserAuthApi.Models.Request;
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
        
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _authService.AuthenticateUserAsync(model.Username, model.Password);

            if (token == null)
            {
                return Unauthorized(); 
            }

            
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _authService.RegisterUserAsync(model.Username, model.Password);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }


            return Ok(new { Message = "Registration successful!" });
        }
    }
}
