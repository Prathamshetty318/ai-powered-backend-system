using AutoMapper;
using MediatR;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using IdentityHub.Application.DTOs;
using IdentityHub.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace IdentityHub.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserResponseDto>>
    {
        private readonly ILogger<GetAllUsersQueryHandler> _logger;
        private readonly IUserDapperRepository _dapperRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;


        public GetAllUsersQueryHandler(IUserDapperRepository dapperRepository, IMapper mapper, IDistributedCache cache, ILogger<GetAllUsersQueryHandler> logger)
        {
            _dapperRepository = dapperRepository;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IEnumerable<UserResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            const string cachekey = "all_users";

            var cachedData = await _cache.GetStringAsync(cachekey);dotnet 

            if (cachedData != null)
            {
                _logger.LogInformation("Fetching users from cache");
                return JsonSerializer.Deserialize<IEnumerable<UserResponseDto>>(cachedData) ?? Enumerable.Empty<UserResponseDto>();
            }

            _logger.LogInformation("Fetching users from database");

            var users = await _dapperRepository.GetAllUserAsync();
            var response = _mapper.Map<IEnumerable<UserResponseDto>>(users);


            var Json = JsonSerializer.Serialize(response);
            await _cache.SetStringAsync(
                cachekey,
                Json,
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });

            _logger.LogInformation("Users cached for 5 minutes in redis from Db");

            return response;
        }

    }


}

