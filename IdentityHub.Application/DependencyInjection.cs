using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using IdentityHub.Application.Mapping;
using IdentityHub.Application.Services;
using IdentityHub.Application.Validators;
using MediatR;
using IdentityHub.Application.Features.Users.Commands.RegisterUser;
using IdentityHub.Application.Behaviours;

namespace IdentityHub.Application;

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
