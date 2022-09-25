using FluentValidation;

namespace Intranet.Application.User.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            _ = RuleFor(x => x.Email).NotNull().WithMessage("Email is required");
            _ = RuleFor(x => x.Password).NotNull().WithMessage("Password is required");
        }
    }
}
