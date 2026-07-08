using Microsoft.AspNetCore.Mvc;
using UserApi.Services;
using UserApi.Entities;
using Microsoft.AspNetCore.Authorization;
using UserApi.DTOs;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using UserApi.Interfaces;
using UserApi.Validators;

namespace UserApi.Controllers
{
	
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly UserService _service;
        private readonly IUserDapperRepository _dapperRepository;

        public UserController(UserService service, IUserDapperRepository dapperRepository)
		{
			_service = service;
			_dapperRepository = dapperRepository;
        }

		
		/*[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}*/

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var user = await _service.GetByIdAsync(id);
			if (user == null) return NotFound();
			return Ok(user);
        }

        [HttpGet("dapper-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result =
                await _service.GetUsersDapperAsync();

            return Ok(result);
        }

        [AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> RegisterUser(RegisterUserDto dto)
		{

            Console.WriteLine("Controller Hit");


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

			var existingUser = await _service.GetByNameAsync(dto.Name);

			if (existingUser != null)
			{
				return BadRequest("User with the same name already exists.");
            }

            await _service.RegisterUserAsync (dto);
			return Ok("User Registered Successfully!!!!");
        }

       




    }
}