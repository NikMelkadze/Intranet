using Intranet.Application.Employee.GetEmployee;
using Intranet.Application.User.Registration;
using Intranet.Persistance.Models;
using MediatR;

namespace Intranet.Application.User.GetUser
{
    public class GetEmployeesQuery : IRequest<GetEmployeesResponse>
    {
    }
    public class GetEmployeesResponse
    {
        public IEnumerable<GetEmployeeResponse> Employees { get; set; }
    }
}
