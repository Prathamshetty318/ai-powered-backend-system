using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Domain.Entities;
using MediatR;
using UserApi.Domain.Interfaces;

namespace UserApi.Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    { 
        private readonly IUnitOfWork _unitOfWork;

        public RegisterUserCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle (RegisterUserCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
