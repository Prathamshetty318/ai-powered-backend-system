using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using IdentityHub.Domain.Interfaces;
using IdentityHub.Infrastructure.Data;
using IdentityHub.Infrastructure.DapperRepositories;
using IdentityHub.Infrastructure.Repositories;

namespace IdentityHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString =
            configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUserDapperRepository, UserDapperRepository>();

        services.AddScoped(typeof(IGenericRepository<>),
            typeof(GenericRepository<>));

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
