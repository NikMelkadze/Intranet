using Intranet.Application.Catalogs.Departments.CreateDepartment;
using Intranet.Application.Common.Models;
using Intranet.Application.Employee.AddEmployeeInterests;
using Intranet.Application.Employee.GetEmployee;
using Intranet.Application.Employee.GetEmployeeInterests;
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

        [HttpGet("Employee/{id}")]
        public async Task<ActionResult<GetEmployeeResponse>> GetEmployee(int id)
        {
            return await Mediator.Send(new GetEmployeeQuery { Id = id });
        }

        [HttpPost("EmployeeInterest")]
        public async Task<CommandResponse> AddEmployeeInterest([FromBody] AddEmployeeInterestCommand model)
        {
            return await Mediator.Send(new AddEmployeeInterestCommand { InterestId = model.InterestId, UserId = model.UserId });
        }

        [HttpGet("EmployeeInterest/{userId}")]
        public async Task<ActionResult<GetEmployeeInterestsVM>> GetEmployeeInterests(int userId)
        {
            return await Mediator.Send(new GetEmployeeInterestsQuery { UserId = userId });
        }
    }
}
