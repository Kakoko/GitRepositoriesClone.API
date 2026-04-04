using GitRepositoriesClone.API.Data.Dtos;
using GitRepositoriesClone.API.Models;
using GitRepositoriesClone.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GitRepositoriesClone.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static List<User> users = new();

        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                PasswordHash = request.Password // simplify for now
            };

            users.Add(user);

            return Ok("User registered");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var user = users.FirstOrDefault(x =>
                x.Username == request.Username &&
                x.PasswordHash == request.Password);

            if (user == null)
                return Unauthorized();

            var token = _authService.GenerateToken(user);

            return Ok(new { token });
        }
    }

}
