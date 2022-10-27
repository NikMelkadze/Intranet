using Intranet.Application.Common.Halpers;
using Intranet.Application.Common.Models;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.Commands.DeleteEmployeeInterest
{
    public class DeleteEmployeeInterestQueryHandler : IRequestHandler<DeleteEmployeeInterestQuery, CommandResponse>
    {
        private readonly IRepository<ApplicationUserDTO> _userService;
        private readonly IRepository<EmployeeInterest> _employeeInterestService;
        public DeleteEmployeeInterestQueryHandler(IRepository<ApplicationUserDTO> userService,
            IRepository<EmployeeInterest> employeeInterestService)
        {
            _userService = userService;
            _employeeInterestService = employeeInterestService;
        }

        public async Task<CommandResponse> Handle(DeleteEmployeeInterestQuery request, CancellationToken cancellationToken)
        {
            var userbyUserId = await _userService.GetById(request.UserId);
            CurrentUserValidation.CheckCurrentUser(request.HttpUser, userbyUserId);

            await _employeeInterestService.DeleteById(request.EmployeeInterestId);

            return new CommandResponse
            {
                Messsage = "Success"
            };
        }
    }
}
