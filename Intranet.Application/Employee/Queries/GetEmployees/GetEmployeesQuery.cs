using Intranet.Application.Employee.GetEmployee;
using Intranet.Application.User.Registration;
using Intranet.Persistance.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Intranet.Application.User.GetUser
{
    public class GetEmployeesQuery : IRequest<GetEmployeesResponse>
    {
        public HttpContext HttpContext { get; set; }
    }
    public class GetEmployeesResponse
    {
        public IEnumerable<GetEmployeeResponse> Employees { get; set; }
    }
}
