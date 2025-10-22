using Microsoft.AspNetCore.Mvc;
using user_form_backend.Models;
using user_form_backend.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using user_form_backend.Services;
using System.Threading.Tasks;

namespace AuthDotNet9.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
       

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var user = await authService.RegisterAsync(request);

            if (user is null)
            {
                return BadRequest("User already exist");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login(UserDto request)
        {
            var result = await authService.LoginAsync(request);
            if (result is null) {
                return BadRequest("Username or Password is incorrect");
            }

            return Ok(result);
        }

        [HttpPost("refresh-token")]

        public async Task<ActionResult<TokenResponseDto>> RefreshToken(RefreshTokenRequestDto request)
        {
            var result = await authService.RefreshTokensAsync(request);

            if (result is null || result.AccessToken is null || result.RefreshToken is null)
            {
                return Unauthorized("Invalid refresh token");
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        
        public IActionResult AuthenticationOnlyEndpoint()
        {
            return Ok("You are Authorized");
        }


        [Authorize(Roles ="Admin")]
        [HttpGet("admin-only")]

        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are a admin");
        }




    }
}
