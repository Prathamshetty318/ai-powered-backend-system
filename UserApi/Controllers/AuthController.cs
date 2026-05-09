using Microsoft.AspNetCore.Mvc;
using UserApi.Services;
using UserApi.Models;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")
    public class AuthController : ControllerBase
    {
        private readonly UserService _service;

        public AuthController(UserService service)
        {
            _service = service;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBo
            dy] User user)
        {
            var validateUser = _service.ValidateUser(user.name , user.password);
            if (validateUser == null) return Unauthorized();
            return Ok(ValidateUser);
        }


    }
}k