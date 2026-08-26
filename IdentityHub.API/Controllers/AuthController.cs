using Microsoft.AspNetCore.Mvc;
using IdentityHub.Application.Services;
using IdentityHub.Domain.Entities;
using IdentityHub.Application.DTOs;


namespace IdentityHub.Controllers
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
