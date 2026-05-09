using Microsoft.AspNetCore.Mvc;
using UserApi.Services;
using UserApi.Models;


namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _service;

        private readonly TokenService _tservice;

        public AuthController(UserService service, TokenService tservice)
        {
            _service = service;

            _tservice = tservice;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User user)
        {
            var validateUser = _service.ValidateUser(user.Name , user.Password);
            if (validateUser == null) return Unauthorized();

            var token = _tservice.GenerateToken(validateUser);
            
            return Ok(new { token });

        }


    }
}