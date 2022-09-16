using FluentValidation;

namespace Intranet.Application.User.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            _ = RuleFor(x => x.Email).NotNull().WithMessage("Emailis required");
            _ = RuleFor(x => x.Password).NotNull().WithMessage("Password Name is required");

        }
    }
}
