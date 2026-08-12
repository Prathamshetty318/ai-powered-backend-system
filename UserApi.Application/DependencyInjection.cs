using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using UserApi.Application.Mapping;
using UserApi.Application.Services;
using UserApi.Application.Validators;
using MediatR;
using UserApi.Application.Features.Users.Commands.RegisterUser;
using UserApi.Application.Behaviours;

namespace UserApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddFluentValidationAutoValidation();

        services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();

        services.AddScoped<UserService>();

        services.AddMediatR(typeof(RegisterUserCommand).Assembly);

        services.AddTransient(typeof(IPipelineBehavior<,>),typeof(LoggingBehavior<,>));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}