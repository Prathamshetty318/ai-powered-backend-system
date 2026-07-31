using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserApi.Application.DTOs;
using AutoMapper;
using MediatR;
using UserApi.Domain.Interfaces;

namespace UserApi.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponseDto>>
    {
        private readonly IUserDapperRepository _dapperRepository;
        private readonly IMapper _mapper;


        public GetAllUsersQueryHandler(IUserDapperRepository dapperRepository, IMapper mapper)
        {
            _dapperRepository = dapperRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _dapperRepository.GetAllUserAsync();

            return _mapper.Map<IEnumerable<UserResponseDto>>(users);
        }

    }


}
