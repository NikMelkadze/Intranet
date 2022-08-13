using Intranet.Application.Services;
using Intranet.Application.User.Login;
using Intranet.Application.User.Registration;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intranet.Controllers
{
    [Route("/User")]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IMediator mediator, IUserService userService) : base(mediator)
        {
            _userService = userService;
        }


        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginQuery model)
        {
            return await Mediator.Send(new LoginQuery { Email = model.Email, Password = model.Password });
        }

        [HttpPost("Registration")]
        public async Task<ActionResult<RegisterResponse>> Register([FromBody] RegisterQuery model)
        {
            return await Mediator.Send(new RegisterQuery { Email = model.Email, Password = model.Password });
        }

        [Authorize]
        [HttpPost("Info")]
        public async Task<ActionResult> UserInfo([FromHeader] UserInfoQuery model)
        {
            return Ok("rame");
        }
    }
}
