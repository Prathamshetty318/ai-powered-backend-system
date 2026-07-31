using Microsoft.AspNetCore.Mvc;
using UserApi.Application.Services;
using UserApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using UserApi.Application.DTOs;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using UserApi.Domain.Interfaces;
using UserApi.Application.Validators;
using AutoMapper;
using UserApi.Application.Features.Users.Commands.RegisterUser;
using MediatR;
using UserApi.Application.Features.Users.Queries.GetAllUsers;


namespace UserApi.Controllers
{
	
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;
		private readonly UserService _service;
        private readonly IUserDapperRepository _dapperRepository;
		private readonly IMapper _mapper;

        public UserController(IMediator mediator, IUserDapperRepository dapperRepository, IMapper mapper, UserService service)
        {
            _mediator = mediator;
            _dapperRepository = dapperRepository;
            _mapper = mapper;
            _service = service;
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

            Console.WriteLine("Controller Hit");
            var result =
                await _mediator.Send(new GetAllUsersQuery());

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

			var command = _mapper.Map<RegisterUserCommand>(dto);

			var result = await _mediator.Send(command);

            return Ok("User Registered Successfully!!!!");
        }

       




    }
}