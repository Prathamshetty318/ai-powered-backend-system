using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using IdentityHub.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using IdentityHub.Domain.Entities;
using Microsoft.Extensions.Configuration;


namespace IdentityHub.Infrastructure.DapperRepositories
{
    public class UserDapperRepository : IUserDapperRepository
    {
        private readonly IConfiguration _configuration;

        public UserDapperRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            var connectionString =
                _configuration.GetConnectionString(
                    "DefaultConnection");

            using var connection =
                new SqlConnection(connectionString);

            return await connection.QueryAsync<User>(
                "GetAllUsers",
                commandType: CommandType.StoredProcedure);
        }

    }
}
