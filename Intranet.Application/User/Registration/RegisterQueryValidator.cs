using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.User.Registration
{
    public class RegisterQueryValidator :AbstractValidator<RegisterQuery>
    {
        public RegisterQueryValidator()
        {
            _ = RuleFor(x => x.Email).NotNull().Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Invalid EMail");
            _ = RuleFor(x => x.Password).NotNull().Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Invalid EMail");

        }
    }
}
