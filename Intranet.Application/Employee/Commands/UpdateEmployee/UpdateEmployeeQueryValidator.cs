using FluentValidation;
using Intranet.Application.User.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.Commands.UpdateEmployee
{
    public class UpdateEmployeeQueryValidator : AbstractValidator<UpdateEmployeeQueryModel>
    {
        public UpdateEmployeeQueryValidator()
        {
            _ = RuleFor(x => x.Password).Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Invalid Passwod");
        }
    }
}
