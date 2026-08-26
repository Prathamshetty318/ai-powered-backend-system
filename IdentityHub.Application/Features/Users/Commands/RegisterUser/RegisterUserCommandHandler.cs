using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityHub.Domain.Entities;
using MediatR;
using IdentityHub.Domain.Interfaces;
using AutoMapper;
using IdentityHub.Application.Features.Users.Commands.RegisterUser;
using Microsoft.Extensions.Caching.Distributed;

namespace IdentityHub.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    { 
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        public RegisterUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache cache)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _cache = cache;
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

            await _cache.RemoveAsync("all_users");

            return User.Id;

        }
    }
}

