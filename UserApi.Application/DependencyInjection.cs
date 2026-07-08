using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using UserApi.Application.Mapping;
using UserApi.Application.Services;
using UserApi.Application.Validators;

namespace UserApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();

        services.AddScoped<UserService>();

        return services;
    }
}