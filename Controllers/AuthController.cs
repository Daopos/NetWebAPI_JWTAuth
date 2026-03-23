using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTAspNet.DTO;
using JWTAspNet.Entities;
using JWTAspNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JWTAspNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {

            var user = await _authService.RegisterASync(request);

            if(user is null)
            {
                return BadRequest("User already exists");
            }

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {

            var token = await _authService.LoginAsync(request);

            if(token is null)
            {
                return BadRequest("Username or password is incorrect");
            }   

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
       public IActionResult AthenticatedOnlyEndpoint()
        {
            return Ok("Authenticated user");
        }


        [Authorize(Roles = nameof(UserRole.Admin))]
        [HttpGet("authenticated/admin")]
        public IActionResult AuthenticatedOnlyEndpointAdmin()
        {
            return Ok("Authenticated Admin");
        }
    }
}
