using Intranet.Application.Catalogs.Departments.CreateDepartment;
using Intranet.Application.Common.Models;
using Intranet.Application.Employee.AddEmployeeInterests;
using Intranet.Application.Employee.Commands.DeleteEmployeeInterest;
using Intranet.Application.Employee.Commands.UpdateEmployee;
using Intranet.Application.Employee.GetEmployee;
using Intranet.Application.Employee.GetEmployeeImage;
using Intranet.Application.Employee.GetEmployeeInterests;
using Intranet.Application.Employee.UploadEmployeeImage;
using Intranet.Application.User.GetUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers
{
    [Route("/Employee")]
    public class EmployeeController : ApiControllerBase
    {
        public EmployeeController(IMediator mediator) : base(mediator)
        {
        }
        #region Employee
        [HttpGet("EmployeeList")]
        public async Task<ActionResult<GetEmployeesResponse>> GetEmployees()
        {
            return await Mediator.Send(new GetEmployeesQuery { });
        }

        [HttpGet("Employee/{userId}")]
        public async Task<ActionResult<GetEmployeeResponse>> GetEmployee(int userId)
        {
            return await Mediator.Send(new GetEmployeeQuery { Id = userId });
        }

        [HttpPut("Employee/{userId}")]
        public async Task<CommandResponse> UpdateEmployee([FromRoute] int userId, [FromBody] UpdateEmployeeQueryModel employee)
        {
            return await Mediator.Send(new UpdateEmployeeQuery
            {
                UserId = userId,
                HttpUser = HttpContext,
                PhoneNumber = employee.PhoneNumber,
                ProfileFacebook = employee.ProfileFacebook,
                ProfileInstagram = employee.ProfileInstagram,
                ProfileLinkedin = employee.ProfileLinkedin,
            });
        }
        #endregion

        #region EmployeeInterest
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

        [HttpDelete("EmployeeInterest/{userId}")]
        public async Task<CommandResponse> DeleteEmployeeInterest([FromRoute] int userId, [FromBody] DeleteEmployeeInterestRequest model)
        {
            return await Mediator.Send(new DeleteEmployeeInterestQuery { EmployeeInterestId = model.EmployeeInterestId, UserId = userId, HttpUser = HttpContext });
        }
        #endregion

        #region Image
        [HttpGet("Image/{userId}")]
        public async Task<ActionResult> GetImage([FromRoute] int userId)
        {
            return await Mediator.Send(new GetEmployeeImageQuery { UserId = userId });
        }

        [HttpPost("Image/{userId}")]
        public async Task<CommandResponse> UploadImage(IFormFile img, [FromRoute] int userId)
        {
            return await Mediator.Send(new UploadEmployeeImageQuery { UserId = userId, HttpUser = HttpContext, Image = img });
        }

        #endregion
    }
}
