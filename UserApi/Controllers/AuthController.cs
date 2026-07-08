using Microsoft.AspNetCore.Mvc;
using UserApi.Services;
using UserApi.Entities;
using UserApi.DTOs;


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
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var validateUser = await _service.ValidateUserAsync(dto.Name , dto.Password);
            if (validateUser == null) return Unauthorized();

            var token = _tservice.GenerateToken(validateUser);
            
            return Ok(new { token });

        }


    }
}