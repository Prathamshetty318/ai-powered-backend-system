using Microsoft.AspNetCore.Mvc;
using UserApi.Services;
using UserApi.Models;

namespace UserApi.Controllers
{

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
		public IActionResult GetAll()
		{
			return Ok(_service.GetAll());
		}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
		{
			var user = _service.GetById(id);
			if (user == null) return NotFound();
			return Ok(user);
		}

		[HttpPost]
		public IActionResult Add(User user)
		{
			_service.Add(user);
			return Ok(user);
		}

		


	}
}