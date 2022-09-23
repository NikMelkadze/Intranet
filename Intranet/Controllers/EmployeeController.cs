using Intranet.Application.Employee.GetEmployee;
using Intranet.Application.User.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers
{
    [Route("/Employee")]
    public class EmployeeController : ApiControllerBase
    {
        public EmployeeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("EmployeeList")]
        public async Task<ActionResult<GetEmployeesResponse>> GetEmployees()
        {
            return await Mediator.Send(new GetEmployeesQuery { });
        }

        [HttpGet("Employee/{Id}")]
        public async Task<ActionResult<GetEmployeeResponse>> GetEmployee(int id)
        {
            return await Mediator.Send(new GetEmployeeQuery { Id = id });
        }
    }
}
