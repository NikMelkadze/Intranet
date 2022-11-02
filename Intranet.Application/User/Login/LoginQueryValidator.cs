using FluentValidation;

namespace Intranet.Application.User.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginRequest>
    {
        public LoginQueryValidator()
        {
            _ = RuleFor(x => x.Email).NotNull().WithMessage("Email is required");
            _ = RuleFor(x => x.Password).NotNull().WithMessage("Password is required");
        }
    }
}
