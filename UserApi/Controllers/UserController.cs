using Microsoft.AspNetCore.Mvc;
using UserApi.Services;
using UserApi.Models;
using Microsoft.AspNetCore.Authorization;

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
		public async Task<IActionResult> Add(User user)
		{
			await _service.AddAsync (user);
			return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

		


	}
}