using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Domain.Entities;
using MediatR;
using UserApi.Domain.Interfaces;
using AutoMapper;
using UserApi.Application.Features.Users.Commands.RegisterUser;

namespace UserApi.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    { 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle (RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var User = _mapper.Map<User>(request);
            await _unitOfWork.Users.AddAsync(User);
                
            await _unitOfWork.AuditLogs.AddAsync(
                new AuditLog
                {
                    Action = $"User {User.Name} registered",
                });

            await _unitOfWork.SaveChangesAsync();

            return User.Id;

        }
    }
}
