using FluentValidation;
using IdentityHub.Application.DTOs;

namespace IdentityHub.Application.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MinimumLength(3);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MinimumLength(6)
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one upper case")
                .Matches(@"[^a-zA-Z0-9]+").WithMessage("Password must contain at least one special character");
        }
    }
}
