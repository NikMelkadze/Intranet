using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intranet.Application.Employee.GetEmployee
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, GetEmployeeResponse>
    {
        private readonly IRepository<ApplicationUserDTO> _userService;

        public GetEmployeeQueryHandler(IRepository<ApplicationUserDTO> userService)
        {
            _userService = userService;
        }

        public async Task<GetEmployeeResponse> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            GetEmployeeResponse result;
            try
            {
                var employee = await _userService.GetById(request.Id);
                 result = new GetEmployeeResponse
                {
                    Email = employee.Email,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    PhoneNumber = employee.PhoneNumber,
                    Department = employee.Department.Name,
                    UserId = employee.UserId,
                    DateOfBirth = employee.DateOfBirth,
                    Position = employee.Position,
                };
            }
            catch (NullReferenceException ex)
            {

                throw new NullReferenceException("Employee with this Id does not exist");
            }

            return result;
        }
    }
}
