using Microsoft.AspNetCore.Mvc;
using UserApi.Services;
using UserApi.Models;
using Microsoft.AspNetCore.Authorization;
using UserApi.DTOs;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using UserApi.Validators;

namespace UserApi.Controllers
{
	
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly UserService _service;

		public UserController(UserService service)
		{
			_service = service;
		}

		
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var result = await _service.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var user = await _service.GetByIdAsync(id);
			if (user == null) return NotFound();
			return Ok(user);
        }


		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Add(CreateUserDto User)
		{

            Console.WriteLine("Controller Hit");


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _service.AddAsync (User);
			return Ok(User);
        }

		


	}
}