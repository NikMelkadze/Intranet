using Intranet.Application.User.Login;
using Intranet.Application.User.Registration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers
{
    [Route("/User")]
    public class UserController : ApiControllerBase
    {

        public UserController(IMediator mediator) : base(mediator)
        {
        }


        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginQuery model)
        {
            return await Mediator.Send(new LoginQuery { Email = model.Email, Password = model.Password });
        }

        [HttpPost("Registration")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterQuery model)
        {
            return await Mediator.Send(new RegisterQuery
            {
                Email = model.Email,
                Password = model.Password,
                DateOfBirth = model.DateOfBirth,
                DepartmentId = model.DepartmentId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                PositionId = model.PositionId,
                UserRole = model.UserRole,
            }
            );
        }

    }
}
