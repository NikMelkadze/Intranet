using Intranet.Application.Employee.GetEmployee;
using Intranet.Application.Services;
using Intranet.Persistance.Contracts;
using Intranet.Persistance.Models;
using MediatR;
using System.Net.Mail;

namespace Intranet.Application.User.GetUser
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, GetEmployeesResponse>
    {
        private readonly IRepository<ApplicationUserDTO> _userService;

        public GetEmployeesQueryHandler(IRepository<ApplicationUserDTO> userService)
        {
            _userService = userService;
        }
        public async Task<GetEmployeesResponse> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            GetEmployeesResponse result;
            try
            {
                var users = await _userService.Get();
                result = new GetEmployeesResponse
                {
                    Employees = users.Select(x => new GetEmployeeResponse
                    {
                        Email = x.Email,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        PhoneNumber = x.PhoneNumber,
                        Department = x.Department.Name,
                        UserId = x.UserId,
                        DateOfBirth = x.DateOfBirth,
                        Position = x.Position,
                    })
                };
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException("Employees do not exist");
            }
            return result;
        }
    }

}
