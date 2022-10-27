using Intranet.Application.Common.Models;
using Intranet.Application.Services;
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
        private readonly IRepository<EmployeeInterest> _employeeInterestService;
        private readonly IUserValidationService _userValidationService;
        public DeleteEmployeeInterestQueryHandler(
            IRepository<EmployeeInterest> employeeInterestService, IUserValidationService userValidationService)
        {
            _employeeInterestService = employeeInterestService;
            _userValidationService = userValidationService;
        }

        public async Task<CommandResponse> Handle(DeleteEmployeeInterestQuery request, CancellationToken cancellationToken)
        {
            await _userValidationService.CheckCurrentUserOperation(request.HttpUser, request.UserId);
            await _employeeInterestService.Delete(new EmployeeInterest
            {
                EmployeeId = request.UserId,
                InterestId = request.InterestId
            });

            return new CommandResponse
            {
                Messsage = "Success"
            };
        }
    }
}
