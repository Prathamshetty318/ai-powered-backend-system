using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using UserApi.DTOs;
using UserApi.Interfaces;
using Microsoft.Data.SqlClient;


namespace UserApi.DapperRepositories
{
    public class UserDapperRepository : IUserDapperRepository
    {
        private readonly IConfiguration _configuration;

        public UserDapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IEnumerable<UserResponseDto>> GetAllUserAsync()
        {
            var connectionString =
                _configuration.GetConnectionString(
                    "DefaultConnection");

            using var connection =
                new SqlConnection(connectionString);

            return await connection.QueryAsync<UserResponseDto>(
                "GetAllUsers",
                commandType: CommandType.StoredProcedure);
        }

    }
}